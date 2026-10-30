VG-Analys – Kajens Cykeluthyrning

1. Analys av problem och bugg

Problembeskrivning

När jag testade mitt cykeluthyrningsprogram upptäckte jag att medlemsrabatten inte fungerade korrekt.

Jag registrerade en kund som heter Maja, 34 år, och svarade ja på frågan om medlemskap.

Sedan hyrde jag en elcykel i tre timmar. Timpriset var 70 kr, vilket gav ett totalpris på 210 kr före rabatt.

Eftersom kunden var medlem skulle hon få 10 % rabatt, men programmet visade 0 kr i rabatt.

Det första kvittot visade:

Pris före rabatt: 210.00 kr
Medlemsrabatt: -0.00 kr
Att betala: 210.00 kr

Hur jag hittade felet

Jag upptäckte felet när jag testade hela uthyrningsprocessen, från kundregistrering till återlämning och kvitto.

När jag såg att rabatten var 0 kr började jag undersöka hur medlemskapet registrerades.

Jag upptäckte att programmet bara accepterade bokstaven j som svar.

Orsaken till felet

Den ursprungliga koden såg ut så här:

bool arMedlem = medlemSvar?.ToLower() == "j";

Problemet var att jag skrev ja istället för j.

Eftersom "ja" inte är lika med "j" blev variabeln arMedlem automatiskt false.

Det gjorde att kunden registrerades som icke-medlem och därför inte fick någon rabatt.

Hur jag löste problemet

Jag ändrade koden så att programmet accepterar både j och ja.

Den nya koden blev:

string svar = Console.ReadLine()?.Trim().ToLower() ?? "";
bool arMedlem = svar == "j" || svar == "ja";

Jag använde:

* Trim() för att ta bort extra mellanslag.
* ToLower() för att omvandla stora bokstäver till små.
* || för att kontrollera om svaret är j eller ja.

På så sätt kan användaren skriva exempelvis j, J, ja eller JA.

Test efter ändringen

Efter att jag ändrade koden startade jag om programmet och registrerade Maja som medlem igen.

Jag hyrde sedan en elcykel i tre timmar och lämnade tillbaka den.

Den här gången visade kvittot:

Pris före rabatt: 210.00 kr
Medlemsrabatt: -21.00 kr
Att betala: 189.00 kr

Beräkningen blev korrekt:

210 × 0,10 = 21 kr i rabatt.

210 − 21 = 189 kr att betala.

Slutsats

Genom testningen upptäckte jag att programmet inte hanterade alla rimliga svar vid medlemsregistreringen.

Jag lärde mig att det är viktigt att kontrollera användarens inmatning och testa flera olika alternativ.

Efter att jag ändrade villkoret fungerade medlemsrabatten korrekt.

⸻

2. Förbättringsförslag – Unika kundnummer

Nuvarande begränsning

I mitt program registreras kunder med namn, ålder och medlemskap.

När en kund ska hyra en cykel söker programmet efter kundens namn med metoden HittaKund().

Problemet är att två olika personer kan ha samma namn.

Om exempelvis två kunder heter Maja kommer programmet att hitta den första kunden i listan som har det namnet.

Det finns därför en risk att programmet väljer fel kund.

Min föreslagna förbättring

Jag skulle vilja förbättra programmet genom att ge varje kund ett unikt kundnummer.

Exempel:

Kundnummer	Namn	Ålder	Medlem
1	Maja	20	Ja
2	Maja	34	Nej
3	Ali	25	Ja

På så sätt skulle programmet kunna skilja mellan kunder även om de har samma namn.

Hur förbättringen skulle kunna implementeras

Först skulle jag lägga till en ny egenskap i klassen Kund:

public int Id { get; set; }

Sedan skulle jag uppdatera konstruktorn så att varje kund får ett ID när den registreras.

Jag skulle också ändra metoden HittaKund() så att den söker efter kundens ID istället för namn.

Exempel:

public Kund? HittaKund(int id)
{
    foreach (Kund kund in KundLista)
    {
        if (kund.Id == id)
        {
            return kund;
        }
    }
    return null;
}

Vid uthyrning skulle personalen ange kundnumret istället för kundens namn.

För att säkerställa att varje kund får ett unikt nummer skulle jag använda en räknare som ökar för varje ny kund.

Nyttan med förbättringen

Den här förbättringen skulle:

* Minska risken för att fel kund väljs vid uthyrning.
* Göra medlemsrabatten säkrare.
* Göra det lättare att hantera flera kunder med samma namn.
* Göra programmet mer tillförlitligt om verksamheten växer.

Varför jag inte har implementerat förbättringen

Jag har valt att behålla den enklare lösningen i min slutliga version eftersom uppgiften inte kräver unika kundnummer.

Däremot tycker jag att unika kundnummer skulle vara en bra vidareutveckling om programmet skulle användas i en riktig cykeluthyrningsverksamhet.

⸻

3. Sammanfattning

Under arbetet med Kajens Cykeluthyrning har jag fått öva på objektorienterad programmering i C#.

Jag har använt klasser, arv, listor, konstruktorer, metoder, villkor och felhantering.

Genom att testa programmet upptäckte jag ett problem med medlemsrabatten som jag kunde analysera och åtgärda.

Jag har också identifierat en förbättringsmöjlighet som skulle göra programmet mer tillförlitligt.

Arbetet har hjälpt mig att förstå varför det är viktigt att inte bara skriva fungerande kod, utan också testa, felsöka och fundera på hur ett program kan förbättras.