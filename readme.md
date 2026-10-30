🚲 Kajens Cykeluthyrning

Om projektet

Kajens Cykeluthyrning är en konsolapplikation utvecklad i C#.

Programmet är skapat som en individuell inlämningsuppgift och är tänkt att användas av personalen på en cykeluthyrning i Göteborg.

Syftet är att hantera kunder, cyklar och uthyrningar samt beräkna korrekta priser och medlemsrabatter.

#Funktioner

Programmet har en meny med sex alternativ:

1. Visa fordon – visar alla cyklar, deras status och batterinivå för elcyklar.
2. Registrera kund – registrerar kundens namn, ålder och medlemskap.
3. Hyr ut – kontrollerar att kunden får hyra fordonet.
4. Lämna tillbaka – beräknar priset, visar kvitto och gör fordonet ledigt igen.
5. Ladda – laddar en ledig elcykel till 100 %.
6. Avsluta – avslutar programmet.

#Fordonstyper

Fordon	Timpris	Åldersgräns
Cykel	40 kr	Minst 15 år
Elcykel	70 kr	Minst 18 år

Elcyklar förbrukar 10 procentenheter batteri per uthyrd timme.

En elcykel med mindre än 30 % batteri kan inte hyras ut förrän den har laddats.

#Regler

* Kunden måste vara minst 15 år för att hyra en vanlig cykel.
* Kunden måste vara minst 18 år för att hyra en elcykel.
* Ett fordon som redan är uthyrt kan inte hyras ut igen.
* Elcyklar måste ha minst 30 % batteri för att kunna hyras ut.
* Antalet uthyrningstimmar måste vara större än 0.
* Medlemmar får 10 % rabatt.
* När ett fordon lämnas tillbaka visas ett kvitto med pris och eventuell rabatt.
* En avslutad uthyrning tas bort från listan med aktiva uthyrningar.

#Teknik

Projektet är utvecklat med:

* C#
* .NET 10
* Visual Studio Code
* Objektorienterad programmering (OOP)

#Projektstruktur

Klass	Ansvar
Fordon	Basklass med gemensamma egenskaper och prisberäkning
Cykel	Vanlig cykel som ärver från Fordon
Elcykel	Elcykel med batterinivå och laddningsfunktion
Kund	Sparar kundinformation
Uthyrning	Kopplar ihop kund, fordon och antal timmar
Cykeluthyrning	Hanterar listor, registrering, uthyrning och återlämning
Program.cs	Innehåller programmets huvudmeny

#Objektorienterad programmering

Programmet använder arv genom att klasserna Cykel och Elcykel ärver från basklassen Fordon.

Basklassen innehåller de gemensamma egenskaperna:

* Nummer
* Timpris
* ÄrUthyrd

Båda fordonsklasserna ärver även metoden BeräknaPris().

Elcykel har dessutom egna metoder för laddning och batteriförbrukning.

Genom att använda arv undviker jag att skriva samma kod flera gånger.

UML-diagram

UML-diagrammet visar projektets klasser, egenskaper, metoder och relationer.

Originalfilen finns också i mappen docs och kan öppnas i draw.io.

Installation och körning

För att köra programmet behöver du ha .NET SDK installerat.

Klona projektet:

git clone https://github.com/Sumaya-yusuf-1/KajensCykeluthyrning.git

Öppna projektmappen:

cd KajensCykeluthyrning

Starta programmet:

dotnet run

Programmet visar då huvudmenyn där användaren kan välja mellan de sex funktionerna.

Testning

Jag har testat bland annat:

* Åldersgränser för cyklar och elcyklar.
* Uthyrning av fordon.
* Förhindrande av dubbel uthyrning.
* Batterinivå och laddning.
* Medlemsrabatt.
* Återlämning och kvitto.
* Ogiltiga fordonsnummer och åldrar.
* Noll och negativa uthyrningstimmar.
* Förhindrande av dubbel återlämning.

VG – Analys och förbättring

Under testningen upptäckte jag ett problem med medlemsrabatten.

När användaren skrev ja vid medlemsregistreringen registrerades kunden som icke-medlem, eftersom programmet bara accepterade j.

Jag ändrade kontrollen så att både j och ja accepteras.

Efter ändringen fungerade rabatten korrekt.

Jag har också identifierat en möjlig förbättring: att införa unika kundnummer så att kunder med samma namn kan identifieras korrekt.

En mer detaljerad beskrivning finns i VG-Analys.md.

Inlämning

Projektet är skapat som en individuell inlämningsuppgift i C#.

Målet är att visa förståelse för klasser, objekt, arv, listor, metoder, villkor och felhantering.