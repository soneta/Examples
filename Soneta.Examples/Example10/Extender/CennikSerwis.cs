using Soneta.Business;
using Soneta.Examples.Example10.Extender;

[assembly: Service(typeof(ICennikSerwis), typeof(CennikSerwis), Published = true)]
namespace Soneta.Examples.Example10.Extender {

    public partial class CennikSerwis : ICennikSerwis {

        private readonly Session _session;

        public CennikSerwis(Session session) {
            _session = session;
        }
    }
}
