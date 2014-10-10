#define EXAMPLE2

using System;
using System.Drawing;
using Soneta.Business;
using Soneta.Business.Db;
using Soneta.CRM;
using Soneta.Examples.Example2.Extender;

// Sposób w jaki należy zarejestrować extender, który póxniej zostanie użyty w interfejsie.
#if EXAMPLE2
[assembly: Worker(typeof(KontrahentNewOgolneExtender))]
#endif
namespace Soneta.Examples.Example2.Extender
{
    class KontrahentNewOgolneExtender
    {
        // Atrybut Context pozwala na wskazanie mechanizmowi tworzenia extenderów
        // jakie property powinny zostać ustawione automatycznie po utworzeniu obiektu
        // extendera. Jeśli w kontekście istnieje obiekt pasujący typem do opisanego 
        // atrybutem property, to po utworzeniu obiektu extendera wartość property zostanie
        // ustawiona wartością znajdującą sie w kontekście (obiekt Context).
        [Context]
        public Kontrahent Kontrahent { get; set; }

        public Image Logo {
            get
            {
                // Wyszukujemy w załącznikach pierwszy o typie obraz, którego nazwa zaczyna się od "logo."
                foreach (Attachment attachemnt in Kontrahent.Attachments)
                    if (attachemnt.SubType == SubTypeType.Picture
                        && attachemnt.IsDefault)
                        // i zwracamy go na zewnątrz
                        return attachemnt.DataAsImage;

                // lub zwracamy null
                return null;
            }
        }
    }
}
