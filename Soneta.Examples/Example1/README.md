###Example 1
-----------------------------------------------------------------------------------------------------

Przykład pokazuje możliwość zastosowania własnej listy w oparciu o istniejące obiekty systemu. Zawiera zdefiniowane własne    View, z którym została powiązana odpowiednia definicja w postaci struktury viewform.xml. 
    
W wyniku zastosowania dodatku, powinna pojawić się dodatkowa grupa w menu głównym programu o nazwie *Soneta.Examples* z opcją *"Towary własne"*, po wybraniu której pojawi się zaimplementowana lista.

* Extender\TowaryUlubioneKontaktuViewInfo.cs

    Przykładowan klasa z implementacją View zbudowanego na bazie tabel.
* Extender\Menu.cs

    Rejestracja listy dla View
* UI\TowaryUlubioneKontaktu.viewform.xml

    Definicja page'a dla View
    
