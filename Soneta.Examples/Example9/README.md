###Example 9
-----------------------------------------------------------------------------------------------------

Przykład pokazuje implementacje własnej klasy, pozwalającej na dynamiczne uzupełnienie zawartości 
formularza. Dla zaimplementowanej klasy została utworzona dedykowana definicja formularza. 
W przykładzie pokazano wykorzystanie elementu *Include* zasilanego kontentem przez metodę zwracającą
dynamiczną wartość formularza zależną od specyficznych warunków. 

W wyniku zastosowania dodatku, powinna pojawić się dodatkowa grupa w menu głównym programu o nazwie 
*Soneta.Examples*, z opcją *"Formularz dynamiczny"*, po wybraniu której pojawi się formularz utworzony
za pośrednictwem kodu programu.

* Extender\DynamicFormExtender.cs

    Przykładowan klasa implementująca dane oraz metody
* Extender\DynamicFormExtender.Ogolne.pageform.xml

    Definicja własnej zakładki powiązanej z własnyą klasą	
