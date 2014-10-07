using Soneta.Business;

namespace Soneta.Examples.Example8.Extender {
    public class Akcja {
        public string Nazwa { get; set; }
        public double Kurs { get; set; }
        public double Zmiana { get; set; }
        public int LiczbaTransakcji { get; set; }

        public DataAppearance GetAppearance() {
            var appearance = new DataAppearance();

            if (Zmiana > 0) {
                appearance.SetForeColorFromName("Green");
            }
            else if (Zmiana < 0) {
                appearance.SetForeColorFromName("Red");
            }

            return appearance;
        }

        public DataAppearance GetAppearanceNazwa() {
            var appearance = new DataAppearance();
            if (LiczbaTransakcji > 100) {
                appearance.SetFontStyleFromName(DataAppearance.FontStyleNames.Bold);
            }
            return appearance;
        }
    }
}
