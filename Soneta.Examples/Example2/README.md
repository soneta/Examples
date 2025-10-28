###Example 2
-----------------------------------------------------------------------------------------------------

Przykład pokazuje możliwość podpięcia dodatkowej zakładki użytkownika dla klasy *Kontrahent*.
Implementacja dodatkowego extendera pokazuje w jaki sposób można dodawać własne informacje
w postaci różnych danych (np. dodatkowe pola nie związane z logiką systemu). W przypadku 
zakładki wprowadzone zostało dodatkowe pole wyświetlające logo kontrahenta. Aby logo
się pojawiło konieczne jest wstawienie kontrahentowi załącznika o nazwie *logo.png*.
 
W wyniku zastosowania dodatku, powinna pojawić się dodatkowa zakładka na formularzu
kontrahenta, która oprócz danych standardowych zakładki ogólnej będzie posiadała również
logo kontrahenta.


* Extender\KontrahentNewOgolneExtender

    Przykładowan klasa implementująca property Logo, które zostało umieszczone na dodatkowej zakładce
* UI\Kontrahent.KontrahentNewOgolne.pageform.xml

    Definicja dodatkowej zakładki
