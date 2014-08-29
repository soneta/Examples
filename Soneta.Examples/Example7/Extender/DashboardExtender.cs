#define EXAMPLE7

using System.Linq;
using Soneta.Business;
using Soneta.Business.App;
using Soneta.Examples.Example7.Extender;
using Soneta.Tools;

#if EXAMPLE7
[assembly: Worker(typeof(DashboardExtender))]
#endif

namespace Soneta.Examples.Example7.Extender {

    public class DashboardExtender {
        public int LiczbaDodatnia
        {
            get { return 12; }
        }

        public int LiczbaUjemna {
            get { return -56; }
        }

        public int MaxObrot {
            get { return (int)DaneObrot.Max(d => d.Obrót); }
        }

        public int MinObrot {
            get { return (int)DaneObrot.Min(d => d.Obrót); }
        }

        public int MaxPopulacja {
            get { return (int)DanePopulacja.Max(d => d.Populacja); }
        }

        public int MinPopulacja {
            get { return (int)DanePopulacja.Min(d => d.Populacja); }
        }

        public Wiersz[] DaneObrot {
            get {
                return obroty();
            }
        }

        public WierszPopulacja[] DanePopulacja {
            get {
                return populacja();
            }
        }

        public class Wiersz {
            public string Miasto { get; set; }
            public string Towar { get; set; }
            public decimal Obrót { get; set; }
            public decimal Marża { get; set; }
        }

        public class WierszPopulacja {
            public string Miasto { get; set; }
            public double Populacja { get; set; }
        }

        private static Wiersz[] obroty() {
            return new[] {
                new Wiersz{ Miasto="Kraków", Towar="A", Obrót=123, Marża=10 },
                new Wiersz{ Miasto="Kraków", Towar="B", Obrót=234, Marża=20 },
                new Wiersz{ Miasto="Kraków", Towar="C", Obrót=345, Marża=30 },
                new Wiersz{ Miasto="Kraków", Towar="D", Obrót=300, Marża=30 }
			};
        }

        private static WierszPopulacja[] populacja() {
            return new[] {
                new WierszPopulacja{ Miasto="Kraków", Populacja=758 },
                new WierszPopulacja{ Miasto="Lublin", Populacja=347 },
                new WierszPopulacja{ Miasto="Warszawa", Populacja=1715 },
                new WierszPopulacja{ Miasto="Poznań", Populacja=550 },
                new WierszPopulacja{ Miasto="Gdańsk", Populacja=460 },
                new WierszPopulacja{ Miasto="Szczecin", Populacja=408 },
                new WierszPopulacja{ Miasto="Wrocław", Populacja=631 }
			};
        }

        public bool IsVisible {
            get {
                return BusApplication.Instance.Is365 && CoreTools.Version.StartsWith("10.5");
            }
        }

    }
}
