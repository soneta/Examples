###Example 6
-----------------------------------------------------------------------------------------------------

Przykład pokazuje możliwość podpięcia workera dla typu Kontrahent z własnymi czynnościami. 
Zaimplementowane czynności wykorzystują różne typy zwracanych rezultatów mające wpływ na zachowanie interfejsu użytkownika. 
W przykładzie zastosowano rezultaty typu *MessageBoxInformation* i *QueryContextInformation*. 
W przykładzie 4 został zastosowany rezultat *NamedStream* pozwalający na zwrócenie pliku.

W wyniku zastosowania dodatku, w menu czynności na liście kontrahentów powinna pojawić się dodatkowa 
sekcja o nazwie Soneta.Examples, która zawiera 4 różne akcje zaimplementowane w przykładzie.

* Extender\ExampleWorker.cs

    Przykładowa klasa extender'a implementująca czynności z zastosowaniem różnych rezultatów.
