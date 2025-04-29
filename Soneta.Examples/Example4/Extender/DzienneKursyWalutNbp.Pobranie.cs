using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soneta.Business;
using Soneta.Business.App;
using Soneta.Business.UI;
using Soneta.Examples.Example3.Extender;

namespace Soneta.Examples.Example4.Extender {

    public partial class DzienneKursyWalutNbp {
        #region Pobranie kursów w formie xml

        public MessageBoxInformation PobierzXml() {
            return new MessageBoxInformation("Pobranie kursow walut w formie XML", "Czy pobrać aktualną tabelę kursów w formie XML") {
                YesHandler = () => {
                    string file;
                    var bytes = loadData(DateTime.Today, out file);
                    return new NamedStream(file, bytes);
                }
            };
        }

        private byte[] loadData(DateTime date, out string file)
        {
            var lastDay = date;
            switch (DateTime.Today.DayOfWeek) {
                case DayOfWeek.Thursday:
                    lastDay = lastDay.AddDays(-1);
                    break;
                case DayOfWeek.Saturday:
                    lastDay = lastDay.AddDays(-1);
                    break;
                case DayOfWeek.Sunday:
                    lastDay = lastDay.AddDays(-2);
                    break;
            }

            var nbpUrl = CfgWalutyNbpExtender.GetValue(Session, "UrlNbp", "http://www.nbp.pl/kursy/xml/a125z");
            nbpUrl += "{0}";
            file = String.Format("{0}.xml", lastDay.ToString("yyMMdd"));
            var url = String.Format(nbpUrl, file);

            using var httpClient = BusApplication.Instance.GetRequiredService<IHttpClientFactory>().CreateClient();
            var bytes = Task.Run(() => httpClient.GetByteArrayAsync(url)).Result; 
            return bytes;
        }

        #endregion Pobranie kursów w formie xml
    }

}
