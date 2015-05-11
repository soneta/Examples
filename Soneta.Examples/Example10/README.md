###Example 10
-----------------------------------------------------------------------------------------------------

Przykład pokazuje możliwość zdalnej wymiany danych przy wykorzystaniu zaimplementowanego w enova365 serwisu WCF. Przykład zawiera implementacje serwisu enova, którego metody zostaną udostępnione przez serwis WCF co umożliwi wymianę danych z dowolnej maszyny w sieci. Przykladowy serwis zawiera prosta implementaję importu i eksportu cennika.
   
W ramach interfejsu użytkownika zarejestrowanie takiego serwiu nie powoduje pojawienia się żadnej grupy w menu głównym programu.

* Extender\CennikSerwis.cs

    Definicja klasy serwisu oraz jego rejestracja.
* Extender\CennikSerwis.ImportujCennik.cs

    Zawiera definicje metody importującej cennik 
* Extender\CennikSerwis.EksportujCennik.cs

    Zawiera definicje metody eksportującej cennik 
    
