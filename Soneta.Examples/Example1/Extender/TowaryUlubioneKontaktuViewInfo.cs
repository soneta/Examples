using Soneta.Business;
using Soneta.CRM;
using Soneta.Examples.Example3.Extender;
using Soneta.Towary;

namespace Soneta.Examples.Example1.Extender {

    public class TowaryUlubioneKontaktuViewInfo : ViewInfo {
        private Context _context;

        public TowaryUlubioneKontaktuViewInfo()
        {
            ResourceName = "TowaryUlubioneKontaktu";
            InitContext += TowaryWlasneViewInfo_InitContext;
            CreateView += TowaryWlasneViewInfo_CreateView;
        }

        [Context(Required = true)]
        public Context Context { get; set; }

        [Context(Required = true)]
        public Session Session { get; set; }

        void TowaryWlasneViewInfo_InitContext(object sender, ContextEventArgs args) {
            _context = args.Context;
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

        protected void Load() {
            SetContext(typeof(KontaktOsoba), Session.Login.Load(this, Key, "KontaktOsoba"));
        }

        protected void Save() {
            Session.Login.Save(this, Key, "KontaktOsoba");
        }
    }

}
