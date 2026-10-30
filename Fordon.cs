namespace KajensCykeluthyrning;

public class Fordon
{
    public int Nummer { get; set; }

    public decimal Timpris { get; set; }

    public bool ÄrUthyrd { get; set; }

    public Fordon(int nummer, decimal timpris)
    {
        Nummer = nummer;
        Timpris = timpris;
        ÄrUthyrd = false;
    }

    public virtual decimal BeräknaPris(int timmar)
    {
        return Timpris * timmar;
    }
}