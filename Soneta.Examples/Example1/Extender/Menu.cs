using Soneta.Business.Licence;
using Soneta.Business.UI;
using Soneta.Examples.Example1.Extender;

[assembly: FolderView("Soneta.Examples",
    Priority = 10,
    Description = "Przykłady implementacji enova365",
    BrickColor = FolderViewAttribute.BlueBrick,
    Icon = "Soneta.Examples.Utils.examples.ico;Soneta.Examples"
    //, Contexts = new object[] { LicencjeModułu.CRM }
)]

[assembly: FolderView("Soneta.Examples/Towary własne",
    Priority = 11,
    Description = "Towary ulubione osoby kontaktowej",
    TableName = "Towary",
    ViewType = typeof(TowaryUlubioneKontaktuViewInfo)
)]
