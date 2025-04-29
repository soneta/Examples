#define OKNO_GLOWNE
#define EXAMPLE1

using Soneta.Business.Licence;
using Soneta.Business.UI;
using Soneta.Examples.Example1.Extender;



#if OKNO_GLOWNE

[assembly: FolderView("Soneta.Examples",
    Priority = 10,
    Description = "Przykłady implementacji enova365",
    IconName = "lista",
    Contexts = new object[] { LicencjeModułu.All }
)]

#endif





#if EXAMPLE1

[assembly: FolderView("Soneta.Examples/Towary własne",
    Priority = 11,
    Description = "Towary ulubione osoby kontaktowej",
    TableName = "Towary",
    ViewType = typeof(TowaryUlubioneKontaktuViewInfo)
)]

#endif