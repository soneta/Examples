using Soneta.Business;
using Soneta.CRM;
using Soneta.Examples.Example3.Extender;
using Soneta.Towary;

namespace Soneta.Examples.Example1.Extender {

    public class TowaryUlubioneKontaktuViewInfo : ViewInfo {

        public TowaryUlubioneKontaktuViewInfo()
        {
            // View wiążemy z odpowiednią definicją viewform.xml poprzez property ResourceName
            ResourceName = "TowaryUlubioneKontaktu";

            // Inicjowanie contextu
            InitContext += TowaryWlasneViewInfo_InitContext;

            // Tworzenie view zawierającego konkretne dane
            CreateView += TowaryWlasneViewInfo_CreateView;
        }

        void TowaryWlasneViewInfo_InitContext(object sender, ContextEventArgs args) {
            args.Context.TryAdd(() => new WParams(args.Context));
        }

        void TowaryWlasneViewInfo_CreateView(object sender, CreateViewEventArgs args) {
            WParams parameters;
            if (!args.Context.Get(out parameters)) 
                return;
            args.View = ViewCreate(parameters);
            args.View.AllowNew = false;
        }

        protected View ViewCreate(WParams pars) {

            var condUlubione = RowCondition.Empty;
            var rc = RowCondition.Empty;
            var tm = TowaryModule.GetInstance(pars.Context.Session);
            var view = tm.Towary.CreateView();

            if(pars.KontaktOsoba == null)
                condUlubione &= new FieldCondition.Null("Zapis", true);
            else
                condUlubione &= new FieldCondition.Equal("Zapis", pars.KontaktOsoba);

            rc &= new FieldCondition.Equal("Blokada", false);
            rc &= new FieldCondition.Exists("TowaryUlubione", "Towar", condUlubione);
            view.Condition &= rc;

            return view;
        }

        #region Widoczność zakładki

        /// <summary>
        /// Metoda pozwalająca na sterowanie widocznościa zakładki.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        ///     true - widoczność zakładki, 
        ///     false - zakładka niewidoczna
        /// </returns>
        public static bool IsVisible(Context context) {
            bool result;
            using (var session = context.Login.CreateSession(true, true)) {
                result = CfgWalutyNbpExtender.GetValue(session, "AktywneTowaryWlasne", false);
            }
            return result;
        }

        #endregion Widoczność zakładki
    }

    public class WParams : ContextBase
    {
        private const string Key = "Soneta.Examples.TowaryUlubione";

        public WParams(Context context) : base(context)
        {
            Load();
        }

        public KontaktOsoba KontaktOsoba {
            get
            {
                if (Context.Contains(typeof (KontaktOsoba)))
                    return (KontaktOsoba) Context[typeof (KontaktOsoba)];
                return null;
            }
            set {
                Context[typeof(KontaktOsoba)] = value;
                Save();
            }
        }

        /// <summary>
        /// Ładowanie parametrów z kontekstu login'a
        /// </summary>
        protected void Load() {
            SetContext(typeof(KontaktOsoba), Context.LoadProperty(this, Key, "KontaktOsoba"));
        }

        /// <summary>
        /// Zapisywanie parametrów w kontekście login'a
        /// </summary>
        protected void Save() {
            Context.SaveProperty(this, Key, "KontaktOsoba");
        }
    }

}
