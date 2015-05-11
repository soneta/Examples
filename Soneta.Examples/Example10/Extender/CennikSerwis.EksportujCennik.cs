using Soneta.Business;
using Soneta.Towary;

namespace Soneta.Examples.Example10.Extender {

    public partial class CennikSerwis {

        public string EksportujCennik(string tsvContent) {
            var tcsvr = initCsvReader();
            tcsvr.Read(tsvContent);
            return tcsvr.ImportException != null ? tcsvr.ImportException.Message : "";
        }

        private SessionCsvReader initCsvReader() {
            var csv = new SessionCsvReader {
                View = initView()
            };
            return csv;
        }

        private View initView() {
            var tm = TowaryModule.GetInstance(_session);
            var view = tm.Towary.CreateView();
            view.Context = Context.Empty.Clone(_session);
            view.NewRowType = typeof (Towar);
            return view;
        }

    }
}
