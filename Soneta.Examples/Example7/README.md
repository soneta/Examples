###Example 7###
-----------------------------------------------------------------------------------------------------

Przykład pokazuje tworzenie elementu dashboard. 

W wyniku zastosowania dodatku, w panelu użytkownika pojawią się dodatkowe element w dahshboard o nazwie 
Soneta.Examples.Obroty i Soneta.Examples.Populacja. Z uwagi na zastosowanie nowych elementów w pageform.xml
przykład będzie działał od wersji 10.5. 

UWAGA !!!

Dla wersji wcześniejszych niż 10.5 przed skompilowaniem dodatku w plikach Dashboard.*.xml
należy usunąć wpisy Class="DashboardItem"

* Extender\DashboardExetnder.cs

    Przykładowa klasa extender'a implementująca dane widoczne na dashboard.
