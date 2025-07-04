namespace RPG;

class Menu
{
    public string userinput1 { get; set; }

    public Menu() { }

    public Menu(string userinput1)
    {
        userinput1 = userinput1;


    }
    static public string MainMenu()
    {
        Console.WriteLine("Welcome to the Game!");
        Console.WriteLine("1. Start the Game");
        Console.WriteLine("2. Character Creation");
        Console.WriteLine("3. Exit");
        string? userinput1 = Console.ReadLine();
        return userinput1;
    }

    


}