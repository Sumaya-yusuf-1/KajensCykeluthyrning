namespace KajensCykeluthyrning;

public class Cykeluthyrning
{
    public List<Fordon> FordonLista { get; set; }
    public List<Kund> KundLista { get; set; }

    public List<Uthyrning> UthyrningsLista { get; set; }

    public Cykeluthyrning()
    {
        FordonLista = new List<Fordon>();
        KundLista = new List<Kund>();
        UthyrningsLista = new List<Uthyrning>();
        FordonLista.Add(new Cykel(1));
        FordonLista.Add(new Cykel(2));
        FordonLista.Add(new Elcykel(3, 80));
        FordonLista.Add(new Elcykel(4, 25));
    }

    public void VisaFordon()
    {
        Console.WriteLine("Nr\tTyp\t\tStatus\tBatteri");

        foreach (Fordon fordon in FordonLista)
        {
            string typ = fordon is Elcykel ? "Elcykel" : "Cykel";
            string status = fordon.ÄrUthyrd ? "Uthyrd" : "Ledig";
            string batteri = "";

            if (fordon is Elcykel elcykel)
            {
                batteri = $"{elcykel.Batteriniva}%";
            }

            Console.WriteLine(
                $"{fordon.Nummer}\t{typ}\t\t{status}\t{batteri}"
            );
        }
    }
    
    public void RegistreraKund()
{
    Console.Write("Namn: ");
    string namn = Console.ReadLine() ?? "";

    Console.Write("Ålder: ");
    string? alderText = Console.ReadLine();

    if (!int.TryParse(alderText, out int alder) || alder < 0)
    {
        Console.WriteLine("Ogiltig ålder.");
        return;
    }

    Console.Write("Medlem (j/n): ");
string svar = Console.ReadLine()?.Trim().ToLower() ?? "";

bool arMedlem = svar == "j" || svar == "ja";

Kund nyKund = new Kund(namn, alder, arMedlem);

KundLista.Add(nyKund);
}

public Kund? HittaKund(string namn)
{
    foreach (Kund kund in KundLista)
    {
        if (kund.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase))
        {
            return kund;
        }
    }

    return null;
}

public Fordon? HittaFordon(int nummer)
{
    foreach (Fordon fordon in FordonLista)
    {
        if (fordon.Nummer == nummer)
        {
            return fordon;
        }
    }

    return null;
}


// Metod för att hyra ut ett fordon
public void HyrUt()
{
Console.Write("Namn: ");
string namn = Console.ReadLine()?.Trim() ?? "";

if (string.IsNullOrWhiteSpace(namn))
{
    Console.WriteLine("Du måste ange ett namn.");
    return;
}

    Kund? kund = HittaKund(namn);

    if (kund == null)
    {
        Console.WriteLine("Kunden finns inte. Registrera kunden först.");
        return;
    }

    Console.Write("Fordonsnummer: ");

    if (!int.TryParse(Console.ReadLine(), out int nummer))
    {
        Console.WriteLine("Ogiltigt fordonsnummer.");
        return;
    }

    Fordon? fordon = HittaFordon(nummer);

    if (fordon == null)
    {
        Console.WriteLine("Fordonet finns inte.");
        return;
    }

    if (fordon.ÄrUthyrd)
    {
        Console.WriteLine("Fordonet är redan uthyrt.");
        return;
    }

    if (fordon is Cykel && kund.Alder < 15)
    {
        Console.WriteLine("Kunden måste vara minst 15 år.");
        return;
    }

    if (fordon is Elcykel && kund.Alder < 18)
    {
        Console.WriteLine("Kunden måste vara minst 18 år för att hyra elcykel.");
        return;
    }

    if (fordon is Elcykel elcykel && elcykel.Batteriniva < 30)
    {
        Console.WriteLine("Elcykeln har för lite batteri. Ladda först.");
        return;
    }

   Console.Write("Antal timmar: ");

if (!int.TryParse(Console.ReadLine(), out int timmar) || timmar <= 0)
{
    Console.WriteLine("Antal timmar måste vara större än 0.");
    return;
}

Uthyrning nyUthyrning = new Uthyrning(kund, fordon, timmar);

UthyrningsLista.Add(nyUthyrning);

fordon.ÄrUthyrd = true;

Console.WriteLine(
    $"{kund.Namn} hyr fordon {fordon.Nummer} i {timmar} timmar."
);
}


public void LamnaTillbaka()
{
    Console.Write("Fordonsnummer: ");

    if (!int.TryParse(Console.ReadLine(), out int nummer))
    {
        Console.WriteLine("Ogiltigt fordonsnummer.");
        return;
    }

    Uthyrning? uthyrning = null;

    foreach (Uthyrning u in UthyrningsLista)
    {
        if (u.Fordon.Nummer == nummer)
        {
            uthyrning = u;
            break;
        }
    }

    if (uthyrning == null)
    {
        Console.WriteLine("Ingen uthyrning hittades för detta fordon.");
        return;
    }

    decimal pris = uthyrning.Fordon.BeräknaPris(uthyrning.AntalTimmar);

    decimal rabatt = 0m;

    if (uthyrning.Kund.ÄrMedlem)
    {
        rabatt = pris * 0.10m;
    }

    decimal totalPris = pris - rabatt;

    if (uthyrning.Fordon is Elcykel elcykel)
    {
        elcykel.ForbrukaBatteri(uthyrning.AntalTimmar);
    }

    uthyrning.Fordon.ÄrUthyrd = false;

    UthyrningsLista.Remove(uthyrning);

    Console.WriteLine("\n===== KVITTO =====");
    Console.WriteLine($"Kund: {uthyrning.Kund.Namn}");
    Console.WriteLine($"Antal timmar: {uthyrning.AntalTimmar}");
    Console.WriteLine($"Timpris: {uthyrning.Fordon.Timpris} kr");
    Console.WriteLine($"Pris före rabatt: {pris:F2} kr");
    Console.WriteLine($"Medlemsrabatt: -{rabatt:F2} kr");
    Console.WriteLine($"Att betala: {totalPris:F2} kr");
}


public void LaddaElcykel()
{
    Console.Write("Fordonsnummer: ");

    if (!int.TryParse(Console.ReadLine(), out int nummer))
    {
        Console.WriteLine("Ogiltigt fordonsnummer.");
        return;
    }

    Fordon? fordon = HittaFordon(nummer);

    if (fordon == null)
    {
        Console.WriteLine("Fordonet finns inte.");
        return;
    }

    if (fordon is not Elcykel elcykel)
    {
        Console.WriteLine("Detta är en vanlig cykel och har inget batteri.");
        return;
    }

    if (elcykel.ÄrUthyrd)
    {
        Console.WriteLine("Elcykeln är uthyrd och kan inte laddas just nu.");
        return;
    }

    elcykel.Ladda();

    Console.WriteLine($"Elcykel {nummer} är nu laddad till {elcykel.Batteriniva}%.");
}
}

