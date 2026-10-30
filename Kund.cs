namespace KajensCykeluthyrning;

public class Kund
{
    public string Namn { get; set; }
    public int Alder { get; set; }
    public bool ÄrMedlem { get; set; }

    public Kund(string namn, int alder, bool ärMedlem)
    {
        Namn = namn;
        Alder = alder;
        ÄrMedlem = ärMedlem;
    }
}