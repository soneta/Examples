using System;
using System.IO;
using System.Text;
using System.Xml;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Examples.Example3.Extender;
using Soneta.Tools;

namespace Soneta.Examples.Example4.Extender {

    public partial class DzienneKursyWalutNbp {

        #region Aktualizacja kursów

        #region Aktualizacja online

        public MessageBoxInformation Aktualizuj()
        {
            return new MessageBoxInformation(Strings.Str_MsgTitle, Strings.Str_MsgText) {
                YesHandler = () => {
                    // Wczytujemy aktualne kursy 
                    aktualizujonline(DateTime.Today);

                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }

        private void aktualizujonline(DateTime date)
        {
            string f;
            var bytes = loadData(date, out f);
            using (var stream = new MemoryStream(bytes)) {
                aktualizuj(stream);                
            }
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

        public bool IsVivibleNbp
        {
            get {
                var nbpUrl = CfgWalutyNbpExtender.GetValue(Session, "UrlNbp", "");
                return !nbpUrl.IsNullOrEmpty();
            }    
        }

        #endregion

        #region Aktualizacja z pliku

        public MessageBoxInformation AktualizujZPliku() {
            return new MessageBoxInformation(Strings.Str_MsgTitle, Strings.Str_MsgText) {
                YesHandler = () => QueryContextInformation.Create<NamedStream>(importFile)
            };
        }

        private object importFile(NamedStream ns) {
            using (var stream = new MemoryStream(ns.GetData())) {
                // Wczytujemy aktualne kursy 
                aktualizuj(stream);
            }
            // Wymuszamy odświeżenie listy 
            Context.Session.InvokeChanged();
            return "Importowanie danych został zakończony pomyślnie.";
        }

        #endregion

        private static string GetNodeValue(XmlNode node, string valueName)
        {
            var result = String.Empty;
            var valueNode = node.SelectSingleNode(valueName);
            if (valueNode != null)
                result = valueNode.InnerText;
            return result;
        }

        private void aktualizuj(Stream stream) {
            var reader = new StreamReader(stream, Encoding.GetEncoding(1250));
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

            foreach (XmlNode pozycja in pozycje) {
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

        #endregion Aktualizacja kursów
    }

}
