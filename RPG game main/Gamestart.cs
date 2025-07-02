using System.Security.Cryptography.X509Certificates;

namespace RPG;

public class Cutsczene
{
    static public string StartingSzene()
    {
        Console.WriteLine($"Loading...  ");
        Thread.Sleep(4000);
        Console.WriteLine("");
        Console.WriteLine("You wake up on a glade in the middle of the dark forest");
        Thread.Sleep(3000);
        Console.WriteLine("It is unusualy quiet for a forest, you hear no signs of life around");
        Thread.Sleep(4000);
        Console.WriteLine("Only the sound of wind in the trees is disturbing the silence");
        Thread.Sleep(3000);
        Console.WriteLine("Otherwise...");
        Thread.Sleep(2500);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("It would be Dead silent");
        Console.ResetColor();
        Thread.Sleep(2000);
        return "";

    }

    static public string PlotM1()
    {
        int chrbonuscheck2 = 0;
        int chrbonuscheck3 = 0;
        int charbonus = 0;
        bool check1 = true;
        string chrActglade;
        Console.WriteLine("You get up on you legs, your head still feels dizzy for some reason.");
        Thread.Sleep(3500);
        Console.WriteLine("You look around and see a narrow opening in the bushes that surround the glade, It looks like its the only way forward.");
        Thread.Sleep(3500);
        Console.WriteLine("What do you do?");
        Thread.Sleep(1000);
        Console.WriteLine("");
        Thread.Sleep(1500);
        do
        {
            Console.WriteLine("1. Follow the Path forward");
            Console.WriteLine("2. Look for something useful on the glade");
            Console.WriteLine("3. Stay and try to listen to surroundings");
            chrActglade = Console.ReadLine();
            if (chrActglade != "1" && chrActglade != "2" && chrActglade != "3")
            {
                Console.WriteLine("Invalid Input");
                check1 = false;
                continue;
            }
            else if (chrActglade == "3")
            {
                Console.WriteLine("You decided to stay and listen to the forest itself.");
                Thread.Sleep(1000);
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(500);
                Console.WriteLine("You hear nothing except the sounds of wind somewhere above");
                Thread.Sleep(2000);
                Console.WriteLine("You feel that this forest it not so simple as it looks. You decide to stay sharp");
                Console.WriteLine("");
                check1 = false;
                if (chrbonuscheck3 == 0)
                {
                    charbonus = charbonus + 1;
                    chrbonuscheck3 = chrbonuscheck3 + 1;
                }



            }
            else if (chrActglade == "2")
            {
                if (chrbonuscheck2 == 0)
                {
                    Console.WriteLine("You decided to look for something useful");
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                    Console.WriteLine("..");
                    Thread.Sleep(1000);
                    Console.WriteLine("...");
                    Thread.Sleep(500);
                    Console.WriteLine("You have found a stick. ");
                    Thread.Sleep(2000);
                    Console.WriteLine("Its heavy and pretty strong so you decide to take it");
                    Console.WriteLine("");
                    Thread.Sleep(1500);
                    check1 = false;

                    charbonus = charbonus + 2;
                    chrbonuscheck2 = chrbonuscheck2 + 1;
                    Items stick = new Items("Stick", 5, 0, 0);
                    Itemlistsystem.Itemlist.Add(stick);
                }
                else { Console.WriteLine("You already searched the Glade. You find nothing useful"); }
            }
            else { check1 = true; }

        } while (!check1);
        string charbonusEnd = Convert.ToString(charbonus);
        return charbonusEnd;
    }

    static public string PlotM2(string bonus)
    {
        Enemy rat = new Enemy("Rat", 9, 30, 3, 10,0); //added here enemy creation for test reasons. Remove afterwards!
        Enemylist.Enemlist.Add(rat);
        Enemy wolf = new Enemy("Wolf", 15, 60, 5, 12,1);
        Enemylist.Enemlist.Add(wolf);
        Dictionary<string, Enemy> Enemys = Enemylist.Enemlist.ToDictionary(c => c.EnemyType);
        wolf = Enemys["Wolf"];
        rat = Enemys["Rat"];
        Console.WriteLine("You go forward through the narrow path ");
        Thread.Sleep(2500);
        if (bonus == "3")
        {
            int escapetry = 0;
            Random randomiser = new Random(0);
            int escapechance = randomiser.Next(101);
            bool fight1over = false;
            Console.WriteLine("When going forward you excerscized caution wielding your stick");
            Thread.Sleep(3000);
            Console.WriteLine("Because you were cautious you spotted a rat that hid in the grass.");
            Thread.Sleep(3000);
            Console.WriteLine("The rat has red glowing eyes and she is prepared for an attack");
            Thread.Sleep(3000);
            Console.WriteLine("Because you noticed her in time you have a chance to escape!");
            Thread.Sleep(2000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {
                    
                    int CharHP = CharacterList.Charlist[0].HP;
                    int CharDmg = CharacterList.Charlist[0].Damage + Itemlistsystem.Itemlist[0].DamageBonus; //TODO later: add class weapons and auto add properties
                    int EnemyHP = rat.EnemyHealth;
                    int EnemyDmg = rat.EnemyDmg; //added that list properties are called from a dictionary instad of calling them via id
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);//use later: weapons, characters etc
                    bool combat1 = fight1.Fight(rat.EnemyType, 5,rat.EnemyINI, 0);
                    fight1over = combat1;
                    bonus = bonus + 1;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 30)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        bonus = "3";
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You couldnt escape! Prepare for Combat!");
                        escapetry = escapetry + 1;
                    }



                }
                else if (escapetry > 0)
                {
                    Console.WriteLine("You already tried to escape !");
                }
                else { Console.WriteLine("Invalid Input"); }
            } while (!fight1over);


        }
        else if (bonus == "2")
        {
            int escapetry = 0;
            Random randomiser = new Random(0);
            int escapechance = randomiser.Next(101);
            bool fight1over = false;
            Console.WriteLine("You were going forward wielding your stick");
            Thread.Sleep(3000);
            Console.WriteLine("In the grass something moved and you notice a rat");
            Thread.Sleep(3000);
            Console.WriteLine("The rat has red glowing eyes and she is prepared for an attack");
            Thread.Sleep(3000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {
                    
                    int CharHP = CharacterList.Charlist[0].HP;
                    int CharDmg = CharacterList.Charlist[0].Damage + 5; //TODO later: add class weapons and auto add properties
                    int EnemyHP = Enemylist.Enemlist[0].EnemyHealth; 
                    int EnemyDmg = Enemylist.Enemlist[0].EnemyDmg;
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat1 = fight1.Fight(rat.EnemyType, 0, rat.EnemyINI,rat.enemyid);
                    fight1over = combat1;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 50)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You couldnt escape! Prepare for Combat!");
                        escapetry = escapetry + 1;
                    }



                }
                else if (escapetry > 0)
                {
                    Console.WriteLine("You already tried to escape !");
                }
                else { Console.WriteLine("Invalid Input"); }
            } while (!fight1over);

        }
        else if (bonus == "1")
        {
            int escapetry = 0;
            Random randomiser = new Random(0);
            int escapechance = randomiser.Next(101);
            bool fight1over = false;
            Console.WriteLine("When going forward you excerscized caution");
            Thread.Sleep(3000);
            Console.WriteLine("Because you were cautious you spotted a rat that hid in the grass.");
            Thread.Sleep(3000);
            Console.WriteLine("The rat has red glowing eyes and she is prepared for an attack");
            Thread.Sleep(3000);
            Console.WriteLine("Because you noticed her in time you have a chance to escape!");
            Thread.Sleep(2000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {
                    
                    int CharHP = CharacterList.Charlist[0].HP;
                    int CharDmg = CharacterList.Charlist[0].Damage; //TODO later: add class weapons and auto add properties
                    int EnemyHP = Enemylist.Enemlist[0].EnemyHealth; 
                    int EnemyDmg = Enemylist.Enemlist[0].EnemyDmg;
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat1 = fight1.Fight(rat.EnemyType, 5, rat.EnemyINI, rat.enemyid);
                    fight1over = combat1;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 30)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You couldnt escape! Prepare for Combat!");
                        escapetry = escapetry + 1;
                    }



                }
                else if (escapetry > 0)
                {
                    Console.WriteLine("You already tried to escape !");
                }
                else { Console.WriteLine("Invalid Input"); }
            } while (!fight1over);
        }
        else if (bonus == "0")
        {
            int escapetry = 0;
            Random randomiser = new Random(0);
            int escapechance = randomiser.Next(101);
            bool fight1over = false;
            Console.WriteLine("You were going forward carefully pushing branches away");
            Thread.Sleep(3000);
            Console.WriteLine("Something moved in the grass beneath you");
            Thread.Sleep(3000);
            Console.WriteLine("It was a rat that was about to atack!");
            Thread.Sleep(3000);
            Console.WriteLine("Because you noticed it too late you have almost no time to escape");
            Thread.Sleep(2000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {
                    
                    int CharHP = CharacterList.Charlist[0].HP;
                    int CharDmg = CharacterList.Charlist[0].Damage; //TODO later: add class weapons and auto add properties
                    int EnemyHP = Enemylist.Enemlist[0].EnemyHealth; 
                    int EnemyDmg = Enemylist.Enemlist[0].EnemyDmg;
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat1 = fight1.Fight(rat.EnemyType, -3, rat.EnemyINI, rat.enemyid);
                    fight1over = combat1;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 70)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You couldnt escape! Prepare for Combat!");
                        escapetry = escapetry + 1;
                    }



                }
                else if (escapetry > 0)
                {
                    Console.WriteLine("You already tried to escape !");
                }
                else { Console.WriteLine("Invalid Input"); }
            } while (!fight1over);
        }
        return bonus;

    }

    static public string PlotM3(string bonus)
    {
        Console.WriteLine("After defeating the rat you decide not to wait any longer");
        Thread.Sleep(3000);
        Console.WriteLine("You go forwad soon coming to a wider road through the forest.");
        Console.WriteLine("It is up to you if you want to follow the road or not");
        Console.WriteLine("");
        Console.WriteLine("1. Follow the road");
        Console.WriteLine("2. Leave the road and go into the forest.");
        Console.WriteLine("");
        string uinpcrossroad1 = Console.ReadLine();
        if // TODO finish the plot part. Try to figure out how to do the item system better. If not able just proceed and use the easier one
        //add info check for the character. its easy so finish tomorow. Dont forget the bericht too and update git.


    }



}