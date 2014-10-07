using System;
using System.IO;
using System.Net;
using Soneta.Business;
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

            var request = (HttpWebRequest)WebRequest.Create(url);
            byte[] bytes;
            using (var webResponse = (HttpWebResponse)request.GetResponse()) {
                using (var sr = webResponse.GetResponseStream()) {

                    bytes = new byte[(int)webResponse.ContentLength];
                    var pos = 0;

                    while (pos < bytes.Length) {
                        if (sr == null) 
                            continue;

                        var bytesRead = sr.Read(bytes, pos, bytes.Length - pos);
                        if (bytesRead == 0) {
                            throw new IOException("Premature end of data");
                        }
                        pos += bytesRead;
                    }
                    if (sr != null) 
                        sr.Close();
                }
                webResponse.Close();
            }
            return bytes;
        }

        #endregion Pobranie kursów w formie xml
    }

}
