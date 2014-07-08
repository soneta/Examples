###Example 5###
-----------------------------------------------------------------------------------------------------

Przykład pokazuje możliwość definiowania page'a dla parametrów zarejestrowanego workera.

W wyniku zastosowania dodatku, w menu czynności na liście towarów powinna pojawić się dodatkowa 
sekcja o nazwie *Soneta.Examples*, która zawiera akcje o nazwie *"Zmiana postfix/prefix"* zaimplementowaną 
w przykładzie.

* Extender\ZmianaNazwTowarowWorker.cs

    Przykładowa klasa worker'a implementująca czynności w opraciu o klasę parametrów z którą powiązany jest zarejestrowany page.
* UI\ZmianaNazwTowarowParams.Ogolne.pageform.xml

    Pageform zarejestrowany dla parametrów metody worker'a
