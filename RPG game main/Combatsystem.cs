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

    public bool Fight(string enemy, int initiativebonus, int initiativeEnemybonus) //Add enemy type to make Fight an automatic method***
    {
        int TempChrdmg = CharDmg;
        int TempEndmg = EnemyDmg;
        int TempChrHp = CharHP;
        int TempEnHp = EnemyHP;
        int Enemyac = Enemylist.Enemlist[0].Enemyac;
        int ACbonus = 0;
        int CharAC1 = CharacterList.Charlist[0].AC + ACbonus;
        bool combatend = false;
        int turnorder = 0;
        Random combatrandomiser = new Random();
        int turnchance = combatrandomiser.Next(100);
        Console.WriteLine("Activating combat mode!");
        Thread.Sleep(1500);
        Console.WriteLine("Rolling for Initiative.");
        Thread.Sleep(3000);
        int playerinitiative = Initiative(initiativebonus);
        Console.WriteLine($"Your initiative is {playerinitiative} ");
        Thread.Sleep(1500);
        int enemyinitiative = Initiative(initiativeEnemybonus);
        Console.WriteLine($"Your enemy is a {enemy}. It has {EnemyHP} HP. ");
        Thread.Sleep(1500);
        Console.WriteLine($"Enemy has an initiative of {enemyinitiative}");
        Thread.Sleep(1500);
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
        do
        {
            int CharACMain = CharacterList.Charlist[0].AC + ACbonus;
            if (turnorder == 0)
            {
                Console.WriteLine("It is your turn!");
                Thread.Sleep(1000);
                ACbonus = 0;
                CharACMain = CharacterList.Charlist[0].AC;
                Console.WriteLine("What will you do in your turn?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Defend");
                Console.WriteLine("3. Items");  //TODO add items in future. Now focus on combat system//
                Console.WriteLine("4. Escape");
                Console.WriteLine("");
                string? uinpturn = Console.ReadLine();
                if (uinpturn == "1")
                {
                    Console.WriteLine($"You atack the {enemy}! ");
                    int hit = combatrandomiser.Next(21);
                    if (hit >= Enemyac && hit != 20)
                    {
                        Console.WriteLine("You scored a hit!");
                        TempChrdmg = combatrandomiser.Next(CharDmg);
                        TempEnHp = TempEnHp - TempChrdmg;
                        Console.WriteLine($"{enemy} sustained {TempChrdmg} damage!");
                        Console.WriteLine($"{enemy} now has {TempEnHp} HP!");
                        if (TempEnHp <= 0)
                        {
                            Console.WriteLine($"{enemy} is dead! Congratulations!");
                            combatend = true;
                            continue;
                        }
                        else
                        {
                            turnorder = turnorder + 1;
                            combatend = false;
                            continue;
                        }

                    }
                    else if (hit < Enemyac)
                    {
                        Console.WriteLine("You miss!");
                        turnorder = turnorder + 1;
                        combatend = false;
                        continue;
                    }
                    else if (hit == 20)
                    {
                        Console.WriteLine("You scored a critical hit!");
                        TempChrdmg = combatrandomiser.Next(CharDmg) * 2;
                        TempEnHp = TempEnHp - TempChrdmg;
                        Thread.Sleep(1000);
                        Console.WriteLine($"{enemy} sustained {TempChrdmg} damage!");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{enemy} now has {TempEnHp} HP!");
                        Thread.Sleep(1000);
                        if (TempEnHp <= 0)
                        {
                            Console.WriteLine($"{enemy} is dead! Congratulations!");
                            combatend = true;
                            continue;
                        }
                        else
                        {
                            turnorder = turnorder + 1;
                            combatend = false;
                            continue;
                        }

                    }


                }
                else if (uinpturn == "2")
                {
                    Thread.Sleep(500);
                    Console.WriteLine("You decided to defend yourself!");
                    ACbonus = 1;
                    CharACMain = CharacterList.Charlist[0].AC + ACbonus;
                    turnorder = turnorder + 1;
                    combatend = false;
                    Thread.Sleep(2000);
                    Console.WriteLine("Your AC is raised by 2 until your next turn!");
                }
                else if (uinpturn == "3")
                {
                    Console.WriteLine("Feature not modeled yet!");
                    turnorder = 0;
                    combatend = false;
                    continue;

                }
                else if (uinpturn == "4")
                {
                    Console.WriteLine("You are trying to escape!");
                    Thread.Sleep(2000);
                    int escchance = combatrandomiser.Next(100) + initiativebonus;
                    if (escchance < 50 + enemyinitiative)
                    {
                        Console.WriteLine("You have Escaped!");
                        combatend = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Escape failed!");
                        initiativebonus = initiativebonus - 10;
                        combatend = false;
                        turnorder = turnorder + 1;
                        continue;
                    }


                }
            }
            else if (turnorder == 1)
            {
                Enemyac = Enemylist.Enemlist[0].Enemyac;
                Console.WriteLine($"{enemy} Has the turn!");
                Thread.Sleep(1000);
                int enact = combatrandomiser.Next(1, 2);
                if (enact == 1)
                {
                    int enhit = combatrandomiser.Next(20);
                    if (enhit > CharACMain)
                    {
                        Console.WriteLine($"{enemy} atacks you!");
                        TempEndmg = combatrandomiser.Next(EnemyDmg);
                        TempChrHp = TempChrHp - TempEndmg;
                        Console.WriteLine($"You sustained {TempEndmg} damage!");
                        Console.WriteLine($"Your HP is lowered to {TempChrHp}");
                        if (TempChrHp <= 0)
                        {
                            Console.WriteLine("You are Dead!");
                            Exit.Endgame();
                        }
                        else
                        {
                            turnorder = 0;
                            combatend = false;
                            continue;
                        }
                    }
                    else if (enhit < CharACMain)
                    {
                        Console.WriteLine($"{enemy} misses!");
                        turnorder = 0;
                        continue;
                    }


                }
                else if (enact == 2)
                {
                    Console.WriteLine($"{enemy} defends itself! Its AC is raised by 1");
                    Enemyac = Enemyac + 1;
                    turnorder = 0;
                    combatend = false;
                }

            }

        } while (!combatend);

        return combatend;

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
