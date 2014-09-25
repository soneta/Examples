#define EXAMPLE1
#define START

using Soneta.Business.Licence;
using Soneta.Business.UI;
using Soneta.Examples.Example1.Extender;



#if START

[assembly: FolderView("Soneta.Examples",
    Priority = 10,
    Description = "Przykłady implementacji enova365",
    BrickColor = FolderViewAttribute.BlueBrick,
    Icon = "Soneta.Examples.Utils.examples.ico;Soneta.Examples"
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