###Przykłady implementacji dla enova365 - Soneta.Examples###
Prezentowany dodatek o nazwie *Soneta.Examples* zawiera przykłady zastosowania mechanizmów tworzenia interface dla enova365. Zaimplementowane rozwiązania działają w użytkowanych przez enova365 interfejsach - *Okienkowy*, *Przeglądarkowy*, *WindowsRT*.


*Soneta.Examples* jest projektem dodatku, w ramach którego zostały zaimplementowane przykłady pogrupowane w folderach projektu:

* ***Example1*** 

    Przykład pokazuje możliwość zastosowania własnej listy w oparciu o istniejące obiekty enova. Zawiera zdefiniowane własne    View, z którym została powiązana odpowiednia definicja w postaci struktury viewform.xml. 
    
    W wyniku zastosowania dodatku, powinna pojawić się dodatkowa grupa w menu głównym programu o nazwie *Soneta.Examples* z opcją *"Towary własne"*, po wybraniu której pojawi się zaimplementowana lista.

* ***Example2*** 

    Przykład pokazuje możliwość podpięcia dodatkowej zakładki użytkownika dla klasy *Kontrahent*.
Implementacja dodatkowego extendera pokazuje w jaki sposób można dodawać własne informacje
w postaci różnych danych (np. dodatkowe pola nie związane z logiką enova365). W przypadku 
zakładki wprowadzone zostało dodatkowe pole wyświetlające logo kontrahenta. Aby logo
się pojawiło konieczne jest wstawienie kontrahentowi załącznika o nazwie *logo.png*.
 
    W wyniku zastosowania dodatku, powinna pojawić się dodatkowa zakładka na formularzu
kontrahenta, która oprócz danych standardowych zakładki ogólnej będzie posiadała również
logo kontrahenta.

* ***Example3*** 

    Przykład pokazuje możliwość podpięcia własnej zakładki konfiguracyjnej dla potrzeb własnego dodatku.
W przykładzie zastosowano mechanizm tworzenia ustawień konfiguracji bezpośrednio w kodzie programu,
bez stosowania pliku *config.xml*.

    W wyniku zastosowania dodatku, w konfiguracji powinna pojawić się dodatkowa zakładka w sekcji o nazwie 
*Soneta.Examples*.


* ***Example4*** 

    Przykład pokazuje implementacje własnej klasy, nie powiązanej z logiką enova365. Dla zaimplementowanej 
klasy została utworzona dedykowana definicja formularza. W przykładzie pokazano wykorzystanie *Command* 
oraz podpięcia do nich własnych metod. 

    W wyniku zastosowania dodatku, powinna pojawić się dodatkowa grupa w menu głównym programu o nazwie 
*Soneta.Examples*, z opcją *"Kursy walut NBP"*, po wybraniu której pojawi się zaimplementowana lista.
    
    Na liście pokazane zostało użycie zaimplementowanej metody extender'a, która uzupełnia dane na liście.
Druga z metod zastosowanych na definicji listy pokazuje możliwość ściągnięcia pliku xml, zawierającego
dane przygotowane po stronie serwera. Dla prawidłowego działania metod konieczne jest uzupełnienie pola  
*"Import kursów walut NBP włączony"* w ustawieniach enova (zakładka *Soneta.Examples*).

* ***Example5*** 

    Przykład pokazuje możliwość definiowania pageform dla parametrów zarejestrowanego workera.

    W wyniku zastosowania dodatku, w menu czynności na liście towarów powinna pojawić się dodatkowa 
sekcja o nazwie *Soneta.Examples*, która zawiera akcje o nazwie *"Zmiana postfix/prefix"* zaimplementowaną 
w przykładzie.


* ***Example6*** 

    Przykład pokazuje możliwość podpięcia workera dla typu Kontrahent z własnymi czynnościami. Zaimplementowane czynności wykorzystują różne typy zwracanych rezultatów mające wpływ na zachowanie interfejsu użytkownika. W przykładzie zastosowano rezultaty typu *MessageBoxInformation* i *QueryContextInformation*. W przykładzie 4 został zastosowany rezultat *NamedStream* pozwalający na zwrócenie pliku.

    W wyniku zastosowania dodatku, w menu czynności na liście kontrahentów powinna pojawić się dodatkowa 
sekcja o nazwie Soneta.Examples, która zawiera 4 różne akcje zaimplementowane w przykładzie.


* ***Example 7***

    Przykład pokazuje tworzenie elementu dashboard. W wyniku zastosowania dodatku, w panelu użytkownika pojawią się dodatkowe elementy w dahshboard o nazwie Soneta.Examples.Obroty, Soneta.Examples.Populacja i Soneta.Examples.GoogleMap. Z uwagi na zastosowanie nowych elementów w pageform.xml przykład będzie działał od wersji 10.5. 
    
    UWAGA !!!

    Aby przykład zadziałał prawidłowo w wersjach od 10.5, przed skompilowaniem dodatku należy dla plików
Dashboard.*.xml ustawić atrybut Embedded Resource.

    Element o nazwie Soneta.Examples.GoogleMap wymaga przygotowania strony html w oparciu o GoogleMap API. Przykład takiej strony html znajduje się w projekcie (Example7\mapa.html). Aby wykorzystać przykład należy wygenerować niezbędny klucz dla GoogleMap API

* Extender\DashboardExetnder.cs

    Przykładowa klasa extender'a implementująca dane widoczne na dashboard.

	
* ***Example 8***

Przykład pokazuje programistyczne możliwości kolorowania wierszy na liście. 

Aby system odpowiedno wyświetlił dany rekord, należy w odpowiedniej klasie (dotyczy to zarówno obiektów biznesowych jak i niesesyjnych)
dodać metodę GetAppearance(). Metoda ta sprawi, że pokolorowany zostanie cały wiersz. Aby pokolorowana została tylko dana komórka, należy 
do metody GetAppearance dodać sufiks zawierający nazwę property np. GetAppearanceNazwa(). 

Obiekt DataAppearance zwracany przez metodę GetAppearance() pozwala ustawić takie właściwości jak kolor tła oraz kolor i styl czcionki.

* Extender\Akcja.cs

    Przykładowa klasa implementująca metody odpowiedzialne za kolorowanie wiersza.