using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Examples.Example3.Extender;
using Soneta.Tools;

namespace Soneta.Examples.Example4.Extender {

    public class DzienneKursyWalutNbp {
        [Context(Required = true)]
        public Context Context { get; set; }

        [Context(Required = true)]
        public Session Session { get; set; }

        #region Widoczność zakładki

        /// <summary>
        /// Metoda pozwalająca na sterowanie widocznościa zakładki.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        ///     true - widoczność zakładki, 
        ///     false - zakładka niewidoczna
        /// </returns>
        public static bool IsVisible(Context context)
        {
            bool result;
            using (var session = context.Login.CreateSession(true, true)) {
                result = CfgWalutyNbpExtender.GetValue(session, "AktywneKursyNbp", false);
            }
            return result;
        }

        #endregion Widoczność zakładki

        #region Property dla formularza

        private SortedDictionary<string,KursWalutyNbp> _kursyWalut;
        public IEnumerable<KursWalutyNbp> KursyWalut {
            get {
                if (_kursyWalut != null) return 
                    _kursyWalut.Values.ToArray();

                _kursyWalut = new SortedDictionary<string, KursWalutyNbp> {
                    {
                        "USD", new KursWalutyNbp {
                            Kod = "USD",
                            Nazwa = "Dolar amerykański",
                            Przelicznik = 1,
                            KursSredni = 3.0589f
                        }
                    },
                    {
                        "CHF", new KursWalutyNbp {
                            Kod = "CHF",
                            Nazwa = "Frank szwajcarski",
                            Przelicznik = 1,
                            KursSredni = 3.4018f
                        }
                    }
                };
                return _kursyWalut.Values.ToArray();
            }
        }

        #endregion Property dla formularza

        #region Aktualizacja kursów

        public MessageBoxInformation Aktualizuj()
        {
            return new MessageBoxInformation(Strings.Str_MsgTitle, Strings.Str_MsgText) {
                YesHandler = () => {
                    // Wczytujemy aktualne kursy 
                    aktualizuj(DateTime.Today);

                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }

        private void aktualizuj(DateTime date)
        {
            string f;
            var bytes = loadData(date, out f);
            var reader = new StreamReader(new MemoryStream(bytes), Encoding.GetEncoding(1250));
            var document = new XmlDocument();
            document.Load(reader);
            var element = document.DocumentElement;
            if (element == null) 
                return;

            var tabelaKursow = element.SelectSingleNode("//tabela_kursow[@typ='A']");

            _kursyWalut.Clear();

            if (tabelaKursow == null) 
                return;

            var pozycje = tabelaKursow.SelectNodes("pozycja");
            if (pozycje == null)
                return;

            foreach (XmlNode pozycja in pozycje)
            {
                if (pozycja == null)
                    continue;

                var przelicznik = GetNodeValue(pozycja, "przelicznik");
                var kursSredni = GetNodeValue(pozycja, "kurs_sredni");
                var kodWaluty = GetNodeValue(pozycja, "kod_waluty");
                var nazwaWaluty = GetNodeValue(pozycja, "nazwa_waluty");

                _kursyWalut.Add(kodWaluty, new KursWalutyNbp {
                    Kod = kodWaluty,
                    Nazwa = nazwaWaluty,
                    Przelicznik = (przelicznik.IsNullOrEmpty() ? 0 : Convert.ToInt32(przelicznik)),
                    KursSredni = (kursSredni.IsNullOrEmpty() ? 0 : Convert.ToDouble(kursSredni))
                });
            }
        }

        private static string GetNodeValue(XmlNode node, string valueName)
        {
            var result = String.Empty;
            var valueNode = node.SelectSingleNode(valueName);
            if (valueNode != null)
                result = valueNode.InnerText;
            return result;
        }

        #endregion Aktualizacja kursów

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
