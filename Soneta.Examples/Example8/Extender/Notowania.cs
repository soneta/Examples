using System.Collections.Generic;

namespace Soneta.Examples.Example8.Extender {

    public class Notowania {
        #region Property dla formularza

        public IEnumerable<Akcja> AktualneNotowania {
            get {
                return new List<Akcja>() {
                    new Akcja() {
                        Nazwa = "ALIOR",
                        Kurs = 82.45f,
                        Zmiana = 1.35f,
                        LiczbaTransakcji = 275
                    },
                     new Akcja() {
                        Nazwa = "ERGIS",
                        Kurs = 4.75f,
                        Zmiana = 0f,
                        LiczbaTransakcji = 5
                    },
                     new Akcja() {
                        Nazwa = "ENEA",
                        Kurs = 16.25f,
                        Zmiana = -0.05f,
                        LiczbaTransakcji = 115
                    },
                     new Akcja() {
                        Nazwa = "GROCLIN",
                        Kurs = 10.98f,
                        Zmiana = 0.01f,
                        LiczbaTransakcji = 237
                    },
                     new Akcja() {
                        Nazwa = "INTEGERPL",
                        Kurs = 213f,
                        Zmiana = 0f,
                        LiczbaTransakcji = 20
                    },
                     new Akcja() {
                        Nazwa = "MENNICA",
                        Kurs = 14.5f,
                        Zmiana = 0.1f,
                        LiczbaTransakcji = 2
                    },
                };
            }
        }

        #endregion Property dla formularza
    }

}
