###Example 4###
-----------------------------------------------------------------------------------------------------

Przykład pokazuje implementacje własnej klasy, nie powiązanej z logiką enova365. Dla zaimplementowanej 
klasy została utworzona dedykowana definicja formularza. W przykładzie pokazano możliwość dodania tzw.
przycisków oraz podpięcia do nich własnych metod. 

W wyniku zastosowania dodatku, powinna pojawić się dodatkowa grupa w menu głównym programu o nazwie 
*Soneta.Examples*, z opcją *"Kursy walut NBP"*, po wybraniu której pojawi się zaimplementowana lista.
    
    Na liście pokazane zostało użycie zaimplementowanej metody extender'a, która uzupełnia dane na liście.
Druga z metod zastosowanych na definicji listy pokazuje możliwość ściągnięcia pliku xml, zawierającego
dane przygotowane po stronie serwera. Dla prawidłowego działania metod konieczne jest uzupełnienie pola  
*"Import kursów walut NBP włączony"* w ustawieniach enova (zakładka *Soneta.Examples*).

* Extender\CfgWalutyNbpExtender.csDzienneKursyWalutNbp.cs

    Przykładowan klasa implementująca dane oraz metody
* Extender\KursWalutyNbp.cs

    Klasa implemenująca pojedynczy wiersz wyświetlany na liście zdefiniowanej na zakładce.
* UI\DzienneKursyWalutNbp.Ogolne.pageform.xml

    Definicja własnej zakładki powiązanej z własnyą klasą	
