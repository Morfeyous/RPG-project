namespace RPG;

public class Combat
{
    public int EnemyHP { get; set; }
    public int CharHP { get; set; }
    public int EnemyDmg { get; set; }
    public int CharDmg { get; set; }

    Combat() { }

    public Combat(int enmhp, int chrhp, int enmdmg, int chrdmg)
    {
        EnemyHP = enmhp;
        CharHP = chrhp;
        EnemyDmg = enmdmg;
        CharDmg = chrdmg;
    }

    public bool Fight(string enemy, int initiativebonus, int initiativeEnemybonus)
    {
        int turnorder = 0;
        Random combatrandomiser = new Random();
        int turnchance = combatrandomiser.Next(101);
        Console.WriteLine("Activating combat mode!");
        Thread.Sleep(1500);
        Console.WriteLine("Rolling for Initiative.");
        Thread.Sleep(3000);
        int playerinitiative = Initiative(initiativebonus);
        Console.WriteLine($"Your initiative is {playerinitiative} ");
        int enemyinitiative = Initiative(initiativeEnemybonus);
        Console.WriteLine($"Your enemy is a {enemy}. It has {EnemyHP} HP. ");
        Console.WriteLine($"Enemy has an initiative of {enemyinitiative}");
        if (enemyinitiative > playerinitiative)
        {
            Console.WriteLine($"{enemy} has the first turn!");
            turnorder = turnorder + 1;
        }
        else if (playerinitiative > enemyinitiative)
        {
            Console.WriteLine($"You have the first turn!");
            turnorder = 0;
        }
        else
        {
            if (initiativebonus > initiativeEnemybonus)
            {
                Console.WriteLine($"You have the first turn!");
                turnorder = 0;
            }
            else if (initiativebonus < initiativeEnemybonus) // Initiative 1 = enemy turn// Initiative 0 = player turn
            {
                Console.WriteLine($"{enemy} has the first turn!");
                turnorder = turnorder + 1;
            }
            else
            {
                Console.WriteLine($"You have the first turn!");
                turnorder = 0;
            }
        }
        if (turnorder == 0)
        {
            Console.WriteLine("What will you do in your turn?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Items");  //TODO add items in future. Now focus on combat system//
            Console.WriteLine("4. Escape");

        }







    }

    public int Initiative(int initiativebonus)
    {
        Random initiativerandomiser = new Random();
        int initiative = initiativerandomiser.Next(21) + initiativebonus;
        return initiative;
    }




}

public class Enemy
{
    public string EnemyType { get; set; }

    public int EnemyDmg { get; set; }
    public int EnemyHealth { get; set; } 
    public  int EnemyINI { get; set; }
    public  int Enemyac { get; set; }

    Enemy() { }

    public Enemy(string EnName, int EnDmg, int EnHp, int EnIni, int EnAC) // todo add armor class(ac) and finish the combat system in the page gamestart!
    {
        EnemyType = EnName;
        EnemyDmg = EnDmg;
        EnemyHealth = EnHp;
        EnemyINI = EnIni;
        Enemyac = EnAC;
    }

    public static void Enemys()
    {
        Enemy rat = new Enemy("Rat",9, 30, 3, 10);
        Enemylist.Enemlist.Add(rat);
        Enemy wolf = new Enemy("Wolf",15, 60, 5, 12);
        Enemylist.Enemlist.Add(wolf);


    }
}

public static class Enemylist
{
    public static List<Enemy> Enemlist = new List<Enemy>();
}
