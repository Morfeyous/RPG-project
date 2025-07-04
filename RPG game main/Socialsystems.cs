namespace RPG;

public class Trade
{
    public static void TradeSystem()
    {
        string userInput = "";
        Console.WriteLine("Welcome to the Trade System!");
        Thread.Sleep(1000);
        do
        {
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Exit");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("You chose to buy.");
                    Buy();
                    break;
                case "2":
                    Console.WriteLine("You chose to sell.");
                    // Implement selling logic here
                    break;
                case "3":
                    Console.WriteLine("Exiting the trade system.");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        } while (userInput != "3");
    }

    public static void Buy()
    {
        Console.WriteLine("Here is the list of items you can buy:");
       Thread.Sleep(1000);
        Console.WriteLine("1. Pickaxe - 5 gold");
        Console.WriteLine("2. Sword - 10 gold");
        Console.WriteLine("3. Shield - 8 gold");
        Console.WriteLine("4. Health Stone - 5 gold");
        Console.WriteLine("5. Exit");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case "1":
                Console.WriteLine("You bought a Pickaxe for 5 gold.");
                if (Game.herogold.Gold < 5)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 5;
                weapon pickaxe = new weapon("Pickaxe", 10, 2);
                Weaponlist.Weaponlists.Add(pickaxe);
                break;
            case "2":
                Console.WriteLine("You bought a Sword for 10 gold.");
                if (Game.herogold.Gold < 10)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 10;
                weapon sword = new weapon("Sword", 15, 3);
                Weaponlist.Weaponlists.Add(sword);
                break;
            case "3":
                Console.WriteLine("You bought a Shield for 8 gold.");
                if (Game.herogold.Gold < 8)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 8;
                Items shield = new Items("Shield", 0, 3, 0);
                Itemlistsystem.Itemlist.Add(shield);
                break;
            case "4":
                Console.WriteLine("You bought a Health Stone for 5 gold.");
                if (Game.herogold.Gold < 5)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 5;
                Items healthStone = new Items("Health Stone", 0, 0, 10);
                Itemlistsystem.Itemlist.Add(healthStone);
                break;
            case "5":
                Console.WriteLine("Exiting the buy menu.");
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    }

}