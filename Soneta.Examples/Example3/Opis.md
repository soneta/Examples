###Example 3###
-----------------------------------------------------------------------------------------------------

Przykład pokazuje możliwość podpięcia własnej zakładki konfiguracyjnej dla potrzeb własnego dodatku.
W przykładzie zastosowano mechanizm tworzenia ustawień konfiguracji bezpośrednio w kodzie programu,
bez stosowania pliku config.xml

W wyniku zastosowania dodatku, powinna pojawić się dodatkowa zakładka w ustawieniach w sekcji o nazwie 
Soneta.Examples.

* Extender\CfgWalutyNbpExtender.cs
Przykładowan klasa implementująca ustawienia konfiguracyjne wykorzystane na dodatkowej zakładce 
* UI\Config.CfgWalutyNbpExtender.pageform.xml
Definicja zakładki konfiguracyjnej

