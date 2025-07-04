using Microsoft.VisualBasic;

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

    public bool Fight(string enemy, int initiativebonus, int initiativeEnemybonus, int enemyid, int weaponbonus)
    {
        int escapecheck = 0;
        int TempChrdmg = CharDmg;
        int TempEndmg = EnemyDmg;
        int TempChrHp = CharHP;
        int TempEnHp = EnemyHP;
        int Enemyac = Enemylist.Enemlist[enemyid].Enemyac;
        int ACbonus = 0;
        int CharAC1 = Game.player.AC + ACbonus; //TODO: Later add weapon bonus
        bool combatend = false;
        int turnorder = 0;
        Random combatrandomiser = new Random();
        int turnchance = combatrandomiser.Next(100);
        //TODO: Vielleicht seperate static funktion ""
        Console.WriteLine("Activating combat mode!");
        Thread.Sleep(1500);
        //
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
            int CharACMain = Game.player.AC + ACbonus; //TODO: Later add weapon bonus
            if (turnorder == 0)
            {
                Console.WriteLine("It is your turn!");
                Thread.Sleep(1000);
                ACbonus = 0;
                CharACMain = Game.player.AC;
                Console.WriteLine("What will you do in your turn?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Defend");
                Console.WriteLine("3. Stats");  //TODO add items in future. Now focus on combat system//
                Console.WriteLine("4. Escape");
                Console.WriteLine("5. Heal");
                Console.WriteLine("");
                string? uinpturn = Console.ReadLine();
                if (uinpturn == "1")
                {
                    Console.WriteLine($"You atack the {enemy}! ");
                    int hit = combatrandomiser.Next(21) + weaponbonus;
                    if (hit >= Enemyac && hit != 20)
                    {
                        Console.WriteLine("You scored a hit!");
                        TempChrdmg = combatrandomiser.Next(CharDmg);
                        TempEnHp = TempEnHp - TempChrdmg;
                        Thread.Sleep(1500);
                        Console.WriteLine($"{enemy} sustained {TempChrdmg} damage!");
                        Thread.Sleep(800);
                        Console.WriteLine($"{enemy} now has {TempEnHp} HP!");
                        Thread.Sleep(500);
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
                        Thread.Sleep(1000);
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
                    ACbonus = 2;
                    CharACMain = Game.player.AC + ACbonus;
                    turnorder = turnorder + 1;
                    combatend = false;
                    Thread.Sleep(2000);
                    Console.WriteLine("Your AC is raised by 2 until your next turn!");
                }
                else if (uinpturn == "3")
                {
                    string charinfo = Game.player.PrintCharInfo();
                    Console.WriteLine(charinfo);
                    Console.WriteLine($"Gold: {Game.herogold.Gold}");
                    foreach (weapon c in Weaponlist.Weaponlists)
                    {
                        Console.WriteLine($"Weapon:\n{c}");
                    }
                    Console.WriteLine("");
                    turnorder = 0;
                    combatend = false;
                }
                else if (uinpturn == "4")
                {
                    Console.WriteLine("You are trying to escape!");
                    Thread.Sleep(2000);
                    int escchance = combatrandomiser.Next(100) + initiativebonus;
                    if (escchance > 50 + enemyinitiative)
                    {
                        Console.WriteLine("You have Escaped!");
                        combatend = true;
                        escapecheck = 1;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Escape failed!");
                        Thread.Sleep(1000);
                        initiativebonus = initiativebonus - 10;
                        combatend = false;
                        escapecheck = 0;
                        turnorder = turnorder + 1;
                        continue;
                    }
                }
                else if (uinpturn == "5")
                {
                    Console.WriteLine("You are trying to heal yourself!");
                    Thread.Sleep(1000);
                    if (Game.player.Inventory.Count == 0)
                    {
                        Console.WriteLine("You have no items to heal yourself with!");
                        Thread.Sleep(1000);
                        turnorder = 0;
                        combatend = false;
                        continue;
                    }
                    else
                    {
                        Items healitem = Game.player.Inventory.Find(item => item.ItemHeal > 0);
                        if (healitem != null)
                        {
                            TempChrHp += healitem.ItemHeal;
                            Console.WriteLine($"You healed yourself for {healitem.ItemHeal} HP! Now you have {TempChrHp} HP!");
                            Thread.Sleep(1000);
                            turnorder = turnorder + 1;
                            combatend = false;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("You have no items to heal yourself with!");
                            Thread.Sleep(1000);
                            turnorder = 0;
                            combatend = false;
                            continue;
                        }
                    }
                }
            }
            else if (turnorder == 1)
            {
                Enemyac = Enemylist.Enemlist[enemyid].Enemyac;
                Console.WriteLine($"{enemy} Has the turn!");
                Thread.Sleep(1000);
                int enact = combatrandomiser.Next(100);
                if (enact < 33)
                {
                    int enhit = combatrandomiser.Next(20) + Enemylist.Enemlist[enemyid].Enemyatackbonus;
                    if (enhit > CharACMain)
                    {
                        Console.WriteLine($"{enemy} atacks you!");
                        Thread.Sleep(1000);
                        TempEndmg = combatrandomiser.Next(EnemyDmg);
                        TempChrHp = TempChrHp - TempEndmg;
                        Console.WriteLine($"You sustained {TempEndmg} damage!");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Your HP is lowered to {TempChrHp}");
                        Thread.Sleep(1000);
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
                        Thread.Sleep(1000);
                        turnorder = 0;
                        continue;
                    }


                }
                else if (enact > 33 && enact < 90)
                {
                    Console.WriteLine($"{enemy} defends itself! Its AC is raised by 1");
                    Thread.Sleep(1000);
                    Enemyac = Enemyac + 1;
                    turnorder = 0;
                    combatend = false;
                }
                else if (enact > 91)
                {
                    double percent = 25;
                    double percentage = Enemylist.Enemlist[enemyid].EnemyHealth * percent / 100;
                    int healed = Convert.ToInt32(percentage);
                    TempEnHp += healed;
                    Console.WriteLine($"{enemy} heals itself with some kind of magic!");
                    Console.WriteLine($"It healed {healed} HP! Now it has {TempEnHp} HP");
                    combatend = false;
                    turnorder = 0;
                    continue;
                }

            }

        } while (!combatend);
        Game.player.HP = TempChrHp;
        if (escapecheck == 0)
        {
            combatend = true;
        }
        else{ combatend = false; }

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
    
    public int Enemyatackbonus { get; set; }

    public int enemyid { get; set; }

    Enemy() { }

    public Enemy(string EnName, int EnDmg, int EnHp, int EnIni, int EnAC,int enbon, int enid)
    {
        EnemyType = EnName;
        EnemyDmg = EnDmg;
        EnemyHealth = EnHp;
        EnemyINI = EnIni;
        Enemyac = EnAC;
        Enemyatackbonus = enbon;
        enemyid = enid;
    }

    public static void Enemys()
    {
        Enemy rat = new Enemy("Rat", 9, 30, 3, 10, 0, 0); // id 0
        Enemylist.Enemlist.Add(rat);
        Enemy wolf = new Enemy("Wolf", 15, 60, 5, 12, 1, 1); // id 1
        Enemylist.Enemlist.Add(wolf);
        Enemy wolfpack = new Enemy("Wolfpack", 30, 200, 60, 3, 10, 2); //id 2
        Enemylist.Enemlist.Add(wolfpack);
        Enemy Werewolf = new Enemy("Werewolf", 50, 400, 40, 13, 5, 3); // id 3
        Enemylist.Enemlist.Add(Werewolf);
        Enemy goblin = new Enemy("Goblin", 20, 100, 5, 5, 0, 4); //id 4
        Enemylist.Enemlist.Add(goblin);


    }
}

public static class Enemylist
{
    public static List<Enemy> Enemlist = new List<Enemy>();
}
