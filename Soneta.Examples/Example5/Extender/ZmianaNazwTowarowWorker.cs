using System.Linq;
using Soneta.Business;
using Soneta.Examples.Example5.Extender;
using Soneta.Tools;
using Soneta.Towary;

[assembly: Worker(typeof(ZmianaNazwTowarowWorker), typeof(Towary))]

namespace Soneta.Examples.Example5.Extender {

    public class ZmianaNazwTowarowWorker : ContextBase {

        public ZmianaNazwTowarowWorker(Context context) : base(context) {
        }

        [Context]
        public ZmianaNazwTowarowParams @params {
            get;
            set;
        }

        [Context]
        public Towar[] Towary {
            get; set;
        }

        [Action("Soneta Examples/Zmiana postfix/prefix", Mode = ActionMode.SingleSession | ActionMode.ConfirmSave | ActionMode.Progress)]
        public void ZmianaNazw() {
            using (var t = @params.Session.Logout(true)) {
                foreach (var towar in Towary.Where(towar => @params.TypTowaru == towar.Typ)) {

                    if (!@params.DodajPrefix.IsNullOrEmpty() && !towar.Nazwa.StartsWith(@params.DodajPrefix)) {
                        towar.Nazwa = @params.DodajPrefix + towar.Nazwa;
                    }

                    if (!@params.DodajPostfix.IsNullOrEmpty() && !towar.Nazwa.StartsWith(@params.DodajPostfix)) {
                        towar.Nazwa = towar.Nazwa + @params.DodajPostfix;
                    }
                }
                t.Commit();
            }
        }
    }

    public class ZmianaNazwTowarowParams : ContextBase {

        public ZmianaNazwTowarowParams(Context context) : base(context) {
            TypTowaru = TypTowaru.Towar;
        }

        public TypTowaru TypTowaru { get; set; }

        public string DodajPrefix { get; set; }

        public string DodajPostfix { get; set; }

        public string UsunPrefix { get; set; }

        public string UsunPostfix { get; set; }
    }
}
