namespace KajensCykeluthyrning;

public class Elcykel : Fordon
{
    public int Batteriniva { get; private set; }

    public Elcykel(int nummer, int batteriniva)
        : base(nummer, 70m)
    {
        Batteriniva = Math.Clamp(batteriniva, 0, 100);
    }

    public void Ladda()
    {
        Batteriniva = 100;
    }

    public void ForbrukaBatteri(int timmar)
    {
        Batteriniva = Math.Max(0, Batteriniva - timmar * 10);
    }
}