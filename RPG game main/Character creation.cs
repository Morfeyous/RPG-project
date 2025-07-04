namespace RPG;

public class Character
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Age { get; set; }
    public int HP { get; set; }

    public int Damage { get; set; }

    public int AC { get; set; }
    public int Initiative { get; set; }

    public List<Items> Inventory { get; set; } = new List<Items>(); // Weapon and inventory lists
    public List<weapon> Weapons { get; set; } = new List<weapon>();
    

    public Character() { }

    public Character(string ChrNm, string ChrSrnm, string ChrAg, int HPstat, int Dmgstat, int Armor, int IniBon)
    {
        Name = ChrNm;
        Surname = ChrSrnm;
        Age = ChrAg;
        HP = HPstat;
        Damage = Dmgstat;
        AC = Armor;
        Initiative = IniBon;
    }

    static public Character Creation()
    {
        
        Character char1 = null;
        bool exitclasscreation = false;
        Console.WriteLine("Chose the name of the character!");
        string Nameinp = Console.ReadLine();
        Console.WriteLine("Chose the Surname of the Character!");
        string Surnameinp = Console.ReadLine();
        Console.WriteLine("Chose the Age of the Character!");
        string Ageinp = Console.ReadLine();
        do
        {

            Console.WriteLine("Chose your class!");
            Console.WriteLine("");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Paladin");
            Console.WriteLine("3. Archer");
            string userchar = Console.ReadLine();
            if (userchar == "1")
            {
                char1 = new Character(Nameinp, Surnameinp, Ageinp, 100, 15, 13, 1);
                //TODO: Vielleicht keine Liste sondern ein Character
                //Diesen Character dann überall verwenden
                exitclasscreation = true;
            }
            else if (userchar == "2")
            {
                char1 = new Character(Nameinp, Surnameinp, Ageinp, 150, 5, 16, -5);
                exitclasscreation = true;
            }
            else if (userchar == "3")
            {
                char1 = new Character(Nameinp, Surnameinp, Ageinp, 50, 25, 11, 10);
                exitclasscreation = true;
            }
            else { Console.WriteLine("Invalid Input!"); }
        } while (!exitclasscreation);

        return char1;
        
    }
    public string PrintCharInfo()
    {
        return $"Name: {Name}\n Surname: {Surname}\n Age: {Age}\n HP: {HP}\n Damage per Atack: {Damage}\n AC: {AC}\n Initiative +{Initiative}";
    }


}


