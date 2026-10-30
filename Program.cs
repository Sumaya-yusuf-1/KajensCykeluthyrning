using KajensCykeluthyrning;

Cykeluthyrning uthyrning = new Cykeluthyrning();

bool korProgrammet = true;

while (korProgrammet)
{
    Console.WriteLine("\n=== Kajens Cykeluthyrning ===");
    Console.WriteLine("1. Visa fordon");
    Console.WriteLine("2. Registrera kund");
    Console.WriteLine("3. Hyr ut");
    Console.WriteLine("4. Lämna tillbaka");
    Console.WriteLine("5. Ladda");
    Console.WriteLine("6. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string? val = Console.ReadLine();

    switch (val)
    {
        case "1":
            uthyrning.VisaFordon();
            break;

        case "2":

            uthyrning.RegistreraKund();

            break;

        case "3":
            uthyrning.HyrUt();
            break;
        case "4":
            uthyrning.LamnaTillbaka();
            break;

        case "5":
    uthyrning.LaddaElcykel();
    break;

        case "6":
            korProgrammet = false;
            Console.WriteLine("Tack för att du använde Kajens Cykeluthyrning!");
            break;

        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }
}