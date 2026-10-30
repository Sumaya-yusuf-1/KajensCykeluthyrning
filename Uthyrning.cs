namespace KajensCykeluthyrning;

public class Uthyrning
{
    public Kund Kund { get; set; }
    public Fordon Fordon { get; set; }
    public int AntalTimmar { get; set; }

    public Uthyrning(Kund kund, Fordon fordon, int antalTimmar)
    {
        Kund = kund;
        Fordon = fordon;
        AntalTimmar = antalTimmar;
    }
}

