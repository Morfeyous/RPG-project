namespace RPG;

class Exit
{
    public static void Exitopt()
    {
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }

    public static void Endgame()
    {
        Console.WriteLine("You tried your best but it wasnt enough. Try one more time, hero");
        Thread.Sleep(5000);
        Environment.Exit(0);
    }
    

}