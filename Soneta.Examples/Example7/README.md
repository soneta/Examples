###Example 7###
-----------------------------------------------------------------------------------------------------

Przykład pokazuje tworzenie elementu dashboard. 

W wyniku zastosowania dodatku, w panelu użytkownika pojawią się dodatkowe elementy w dahshboard o nazwie 
Soneta.Examples.Obroty, Soneta.Examples.Populacja i Soneta.Examples.GoogleMap. Z uwagi na zastosowanie 
nowych elementów w pageform.xml przykład będzie działał od wersji 10.5.

UWAGA !!!

Aby przykład zadziałał prawidłowo w wersjach od 10.5, przed skompilowaniem dodatku należy dla plików
Dashboard.*.xml ustawić atrybut Embedded Resource.

* Extender\DashboardExetnder.cs

    Przykładowa klasa extender'a implementująca dane widoczne na dashboard.