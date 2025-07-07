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
        Console.WriteLine("5. Silver Sword - 50 gold");
        Console.WriteLine("6. Crystal Shield - 40 gold");
        Console.WriteLine("7. Adamantine Lance - 100 gold");
        Console.WriteLine("8. Dragon Scale Armor - 200 gold");
        Console.WriteLine("9. The Ultimate Sword - 500 gold");
        Console.WriteLine("10. The Ultimate Shield - 400 gold");
        Console.WriteLine("11. Exit");
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
                Game.player.Inventory.Add(shield);
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
                Game.player.Inventory.Add(healthStone);
                break;
            case "5":
                Console.WriteLine("You bought a Silver Sword for 50 gold.");
                if (Game.herogold.Gold < 50)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 50;
                weapon silverSword = new weapon("Silver Sword", 25, 5);
                Weaponlist.Weaponlists.Add(silverSword);
                break;
            case "6":
                Console.WriteLine("You bought a Crystal Shield for 40 gold.");
                if (Game.herogold.Gold < 40)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 40;
                weapon crystalShield = new weapon("Crystal Shield", 20, 4);
                Weaponlist.Weaponlists.Add(crystalShield);
                break;
            case "7":
                Console.WriteLine("You bought an Adamantine Lance for 100 gold.");
                if (Game.herogold.Gold < 100)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 100;
                weapon adamantineLance = new weapon("Adamantine Lance", 30, 6);
                Weaponlist.Weaponlists.Add(adamantineLance);
                break;
            case "8":
                Console.WriteLine("You bought Dragon Scale Armor for 200 gold.");
                if (Game.herogold.Gold < 200)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 200;
                Items dragonScaleArmor = new Items("Dragon Scale Armor", 0, 5, 0);
                Game.player.Inventory.Add(dragonScaleArmor);
                break;
            case "9":
                Console.WriteLine("You bought The Ultimate Sword for 500 gold.");
                if (Game.herogold.Gold < 500)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 500;
                weapon ultimateSword = new weapon("The Ultimate Sword", 50, 10);
                Weaponlist.Weaponlists.Add(ultimateSword);
                break;
            case "10":
                Console.WriteLine("You bought The Ultimate Shield for 400 gold.");
                if (Game.herogold.Gold < 400)
                {
                    Console.WriteLine("You do not have enough gold to buy this item.");
                    return;
                }
                Game.herogold.Gold -= 400;
                Items ultimateShield = new Items("The Ultimate Shield", 0, 10, 0);
                Game.player.Inventory.Add(ultimateShield);
                break;
            case "11":
                Console.WriteLine("Exiting the buy menu.");
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    }

}