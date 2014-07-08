using Soneta.Business.Licence;
using Soneta.Business.UI;
using Soneta.Examples.Example1.Extender;

[assembly: FolderView("Soneta.Examples",
    Priority = 9000,
    Description = "Przykłady rozszerzeń wykorzystujących technologię enova365",
    Icon = "Soneta.Examples.Utils.examples.ico;Soneta.Examples",
    Contexts = new object[] { LicencjeModułu.CRM }
)]

[assembly: FolderView("Soneta.Examples/Towary własne",
    Priority = 9001,
    Description = "Towary ulubione osoby kontaktowej",
    TableName = "Towary",
    ViewType = typeof(TowaryUlubioneKontaktuViewInfo)
)]
