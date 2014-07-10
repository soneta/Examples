using Soneta.Business.UI;
using Soneta.Examples.Example4.Extender;

[assembly: FolderView("Soneta.Examples/Kursy walut NBP",
    Priority = 12,
    Description = "Przykład kursów walut pobieranych z NBP online",
    ObjectType = typeof(DzienneKursyWalutNbp),
    ObjectPage = "DzienneKursyWalutNbp.Ogolne.pageform.xml",
    ReadOnlySession = false,
    ConfigSession = false
)]
