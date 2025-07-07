using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace RPG;

public class Cutsczene
{
    static public string StartingSzene()
    {
        Narrate("Loading...  ", 4000);
        Narrate("", 1500);
        Narrate("You wake up on a glade in the middle of the dark forest", 3000);
        Narrate("It is unusualy quiet for a forest, you hear no signs of life around", 4000);
        Narrate("Only the sound of wind in the trees are disturbing the silence", 3000);
        Narrate("Otherwise...", 1000);
        Console.ForegroundColor = ConsoleColor.Red;
        Narrate("Otherwise it would be Deadly Silent", 2000);
        Console.ResetColor();
        Narrate("", 2000);
        return "";

    }

    static public string PlotM1()
    {
        int chrbonuscheck2 = 0;
        int chrbonuscheck3 = 0;
        int charbonus = 0;
        bool check1 = true;
        string chrActglade;
        Narrate("You get up on you legs, your head still feels dizzy for some reason.", 3500);
        Narrate("You look around and see a narrow opening in the bushes that surround the glade, It looks like its the only way forward.", 3500);
        Narrate("What do you do?", 1000);
        Narrate("", 1500);
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
                Narrate("You decided to stay and listen to the forest itself.", 1000);
                Narrate(".", 1000);
                Narrate("..", 1000);
                Narrate("...", 1000);
                Narrate("You hear nothing except the sounds of wind somewhere above", 2000);
                Narrate("You feel that this forest it not so simple as it looks. You decide to stay sharp", 3000);
                Console.WriteLine("");
                check1 = false;
                if (chrbonuscheck3 == 0)
                {
                    Game.player.Initiative = Game.player.Initiative + 1;
                    charbonus = charbonus + 1;
                    chrbonuscheck3 = chrbonuscheck3 + 1;
                }



            }
            else if (chrActglade == "2")
            {
                if (chrbonuscheck2 == 0)
                {
                    Narrate("You decided to look for something useful", 1000);
                    Narrate(".", 1000);
                    Narrate("..", 1000);
                    Narrate("...", 1000);
                    Narrate("You have found a stick.", 2000);
                    Narrate("Its heavy and pretty strong so you decide to take it", 2000);
                    Narrate("", 1500);
                    check1 = false;

                    charbonus = charbonus + 2;
                    chrbonuscheck2 = chrbonuscheck2 + 1;
                    weapon stick = new weapon("Stick", 5, 1);
                    Weaponlist.Weaponlists.Add(stick);
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
        Enemy rat = new Enemy("Rat", 9, 30, 3, 10, 0, 0);
        Enemylist.Enemlist.Add(rat);
        Enemy wolf = new Enemy("Wolf", 15, 60, 5, 12, 1, 1);
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
            Narrate("When going forward you excerscized caution wielding your stick", 3000);
            Narrate("Because you were cautious you spotted a rat that hid in the grass.", 3000);
            Narrate("The rat has red glowing eyes and she is prepared for an attack", 3000);
            Narrate("Because you noticed her in time you have a chance to escape!", 2000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {

                    int CharHP = Game.player.HP;
                    int CharDmg = Game.player.Damage + Weaponlist.Weaponlists[0].DmgAdd(); //TODO later: add class weapons and auto add properties
                    int EnemyHP = rat.EnemyHealth;
                    int EnemyDmg = rat.EnemyDmg; //added that list properties are called from a dictionary instad of calling them via id
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);//use later: weapons, characters etc
                    bool combat1 = fight1.Fight(rat.EnemyType, 5, rat.EnemyINI, 0, 0);
                    fight1over = true;
                    if (combat1 == true)
                    {
                        bonus = "true";
                    }
                    else if (combat1 == false)
                    {
                        bonus = "false";
                    }
                    Console.WriteLine("You recieve 5 gold!");
                    Game.herogold.Gold += 5;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 30)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        bonus = "false";
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
            Narrate("You were going forward wielding your stick", 3000);
            Narrate("In the grass something moved and you notice a rat", 3000);
            Narrate("The rat has red glowing eyes and she is prepared for an attack", 3000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {

                    int CharHP = Game.player.HP;
                    int CharDmg = Game.player.Damage + 5; //TODO later: add class weapons and auto add properties
                    int EnemyHP = Enemylist.Enemlist[0].EnemyHealth;
                    int EnemyDmg = Enemylist.Enemlist[0].EnemyDmg;
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat1 = fight1.Fight(rat.EnemyType, 0, rat.EnemyINI, rat.enemyid, 0);
                    fight1over = true;
                    if (combat1 == true)
                    {
                        bonus = "true";
                    }
                    else if (combat1 == false)
                    {
                        bonus = "false";
                    }
                    Console.WriteLine("You recieve 5 gold!");
                    Game.herogold.Gold += 5;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 50)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        bonus = "false";
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
            Narrate("When going forward you excerscized caution wielding your stick", 3000);
            Narrate("Because you were cautious you spotted a rat that hid in the grass.", 3000);
            Narrate("The rat has red glowing eyes and she is prepared for an attack", 3000);
            Narrate("Because you noticed her in time you have a chance to escape!", 2000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {

                    int CharHP = Game.player.HP;
                    int CharDmg = Game.player.Damage; //TODO later: add class weapons and auto add properties
                    int EnemyHP = Enemylist.Enemlist[0].EnemyHealth;
                    int EnemyDmg = Enemylist.Enemlist[0].EnemyDmg;
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat1 = fight1.Fight(rat.EnemyType, 5, rat.EnemyINI, rat.enemyid, 0);
                    fight1over = true;
                    if (combat1 == true)
                    {
                        bonus = "true";
                    }
                    else if (combat1 == false)
                    {
                        bonus = "false";
                    }
                    Console.WriteLine("You recieve 5 gold!");
                    Game.herogold.Gold += 5;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 30)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        bonus = "false";
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
            Narrate("You were going forward carefully pushing branches away", 3000);
            Narrate("Something moved in the grass beneath you", 3000);
            Narrate("It was a rat that was about to atack!", 3000);
            Narrate("Because you noticed it too late you have almost no time to escape", 3000);
            do
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Try to Escape");
                string uinpfight1 = Console.ReadLine();
                if (uinpfight1 == "1")
                {

                    int CharHP = Game.player.HP;
                    int CharDmg = Game.player.Damage; //TODO later: add class weapons and auto add properties
                    int EnemyHP = Enemylist.Enemlist[0].EnemyHealth;
                    int EnemyDmg = Enemylist.Enemlist[0].EnemyDmg;
                    Combat fight1 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat1 = fight1.Fight(rat.EnemyType, -3, rat.EnemyINI, rat.enemyid, 0);
                    fight1over = true;
                    if (combat1 == true)
                    {
                        bonus = "true";
                    }
                    else if (combat1 == false)
                    {
                        bonus = "false";
                    }
                    Console.WriteLine("You recieve 5 gold!");
                    Game.herogold.Gold += 5;
                    continue;


                }
                else if (uinpfight1 == "2" && escapetry == 0)
                {
                    if (escapechance > 70)
                    {
                        Console.WriteLine("You Escaped!");
                        fight1over = true;
                        bonus = "false";
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
        string outcome1 = "0";
        bool crossroadend = false;
        if (bonus == "true")
        {
            Console.WriteLine("After defeating the rat you decide not to wait any longer");
            Thread.Sleep(3000);
        }
        Console.WriteLine("You go forward, soon coming to a wider road through the forest.");
        Thread.Sleep(3000);
        Console.WriteLine("It is up to you if you want to follow the road or not");
        do
        {
            Thread.Sleep(3000);
            Console.WriteLine("");
            Console.WriteLine("1. Follow the road");
            Console.WriteLine("2. Leave the road and go into the forest.");
            Console.WriteLine("");
            string uinpcrossroad1 = Console.ReadLine();
            if (uinpcrossroad1 == "1")
            {
                outcome1 = "3";
                crossroadend = true;
                continue;



            }
            else if (uinpcrossroad1 == "2")
            {
                string decision2 = PlotB2();
                outcome1 = decision2;
                crossroadend = true;


            }
            else { Console.WriteLine("Invalid command!"); }
        } while (!crossroadend);
        return outcome1; // TODO finish the plot part. Try to figure out how to do the item system better. If not able just proceed and use the easier one
        //add info check for the character. its easy so finish tomorow. Dont forget the bericht too and update git.


    }

    static public string PlotB1() //1 - mines // 2 - village
    {
        int uinpdesiccross = 0;
        bool crossroadend2 = false;
        Console.WriteLine("You decide to follow the road!");
        Thread.Sleep(3000);
        Console.WriteLine("This road looks like the only thread connecting you to the real world");
        Thread.Sleep(3000);
        Console.WriteLine("And the dark forest around you is something that goes out of it");
        Thread.Sleep(3000);
        Console.WriteLine("After a brief moment of walking you notice that road starts to widen");
        Thread.Sleep(3000);
        Console.WriteLine("Finaly you reach an another crossroad");
        Thread.Sleep(3000);
        Console.WriteLine("The road goes left and right");
        Thread.Sleep(3000);
        Console.WriteLine("You also see a sign that says");
        Thread.Sleep(3000);
        Console.WriteLine("Crystal Mines--> \n <--Miner Village");
        Thread.Sleep(3000);
        Console.WriteLine("And yet again it is your decision where to go");
        Thread.Sleep(3000);
        do
        {
            Console.WriteLine("1.Crystal Mines");
            Console.WriteLine("2.Miner Village");
            Console.WriteLine("");
            Console.WriteLine("You WILL be able to return*");
            string uinpcrossroad2 = Console.ReadLine();
            if (uinpcrossroad2 == "1")
            {
                uinpdesiccross = uinpdesiccross + 1;
                crossroadend2 = true;
                continue;
            }
            else if (uinpcrossroad2 == "2")
            {
                uinpdesiccross = uinpdesiccross + 2;
                crossroadend2 = true;
                continue;
            }
            else { Console.WriteLine("Invalid Input!"); }
        } while (!crossroadend2);
        string PlotB1Decis1 = Convert.ToString(uinpdesiccross);
        return PlotB1Decis1;

    }

    static public string PlotB2()
    {
        Random randomiser = new Random(0);
        int escapechance = randomiser.Next(101);
        int escapetry = 0;
        string plotb2end = "0";
        bool fight2over = false;
        Narrate("You decide to strand in the forest in case there is an ambush on the road", 4000);
        Narrate("You go deeper and deeper into the darkness", 3000);
        Narrate("You hear strange sounds somewhere deep in the forest", 3000);
        Narrate("Suddenly the bushes in front of you start to shake", 3000);
        Narrate("A gray wolf walks out of them and looks right at you", 3000);
        Narrate("There is some distance between you but you are certain that running away from this one is not an option", 5000);
        Narrate("The wolf howls and you hear distant answer of his brothers.", 3000);
        Narrate("What will you do?", 3000);
        Console.WriteLine("");
        do
        {
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Try to escape back to the road");
            Console.WriteLine("3. Try to escape deeper into the forest");
            Console.WriteLine("4. Check stats");
            Console.WriteLine("");
            Thread.Sleep(1000);

            string uinpdecisforest = Console.ReadLine();
            if (uinpdecisforest == "1")
            {
                int CharHP = Game.player.HP;
                var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Stick");
                int CharDmg = Game.player.Damage + (stick?.DamageBonus ?? 0);
                int EnemyDmg = Enemylist.Enemlist[1].EnemyDmg;
                int EnemyHP = Enemylist.Enemlist[1].EnemyHealth;
                int enemyini = Enemylist.Enemlist[1].EnemyINI;
                string enemytype = Enemylist.Enemlist[1].EnemyType;
                Combat fight2 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                bool combat2 = fight2.Fight(enemytype, 0, enemyini, 1, 0);
                fight2over = true;
                Console.WriteLine("You recieved 10 gold"); // todo add escape branch for plot in this battle
                Game.herogold.Gold += 10;
                Thread.Sleep(4000);
                plotb2end = "1";

            }
            else if (uinpdecisforest == "2" && escapetry == 0)
            {
                if (escapechance > 60)
                {
                    Console.WriteLine("You Escaped!");
                    fight2over = true;
                    plotb2end = "2";
                    continue;
                }
                else
                {
                    Console.WriteLine("You couldnt escape! Prepare for Combat!");
                    escapetry = escapetry + 1;
                }


            }
            else if (uinpdecisforest == "3" && escapetry == 0)
            {
                if (escapechance > 30)
                {
                    Console.WriteLine("You Escaped!");
                    fight2over = true;
                    plotb2end = "3";
                    continue;
                }
                else
                {
                    Console.WriteLine("You couldnt escape! Prepare for Combat!");
                    escapetry = escapetry + 1;
                }

            }
            else if (uinpdecisforest == "4")
            {
                string charinfo = Game.player.PrintCharInfo();
                Console.WriteLine(charinfo);
                Console.WriteLine($"Gold: {Game.herogold.Gold}");
                foreach (weapon c in Weaponlist.Weaponlists)
                {
                    Console.WriteLine($"Weapon:\n{c}");
                }
                fight2over = false;
                continue;

            }
            else { Console.WriteLine("Invalid Input!"); }
        } while (!fight2over);
        return plotb2end;


    }

    public static string PlotB2V1(string plotb2end)
    {
        Enemy wolfpack = new Enemy("Wolfpack", 30, 200, 60, 7, 3, 2); //id 2
        Enemylist.Enemlist.Add(wolfpack);
        string plotB2V1end = "0";
        Narrate("After defeating the wolf you hear howling that is coming towards you from the deep forest", 3000);
        Narrate("You still have a chance to try and escape the scene until they found you", 4000);
        Narrate("What do you do?", 1500);
        Narrate("", 500);
        Narrate("1. Run back to the road", 0);
        Narrate("2. Stay and fight", 0);
        Narrate("3. Run in another direction deeper into the forest", 0);
        string uinpdesiforest2 = Console.ReadLine();
        if (uinpdesiforest2 == "1")
        {
            plotB2V1end = "3";
        }
        else if (uinpdesiforest2 == "2")
        {
            Narrate("You decide to stay and fight", 3000);
            Narrate("A wolfpack emerges from the darkness", 3500);
            Narrate("There is a lot of them and you feel shivers crawling down your spine", 3500);
            Narrate("You notice that you are surrounded and there is no way to escape", 3500);
            Narrate("Good Luck...", 2500);
            int CharHP = Game.player.HP;
            var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Stick");
            int CharDmg = Game.player.Damage + (stick?.DamageBonus ?? 0);
            int EnemyDmg = Enemylist.Enemlist[2].EnemyDmg;
            int EnemyHP = Enemylist.Enemlist[2].EnemyHealth;
            int enemyini = Enemylist.Enemlist[2].EnemyINI;
            string enemytype = Enemylist.Enemlist[2].EnemyType;
            Combat fight3 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
            bool combat2 = fight3.Fight(enemytype, 0, enemyini, 2, Weaponlist.Weaponlists[0].Hitbonus);
            Narrate("You have managed to kill them all", 3000);
            Narrate("You recieved 150 gold", 2000);
            Game.herogold.Gold += 150;
            Narrate("You decide to go back to the road. Who knows who else can hide in this forest", 3000);
            Narrate("Or what else...", 2000);
            plotB2V1end = "3";


        }
        else if (uinpdesiforest2 == "3")
        {
            plotB2V1end = "2";

        }
        return plotB2V1end;
    }

    public static string PlotB2V2() //forward into the forest
    {
        Enemy Werewolf = new Enemy("Werewolf", 50, 400, 40, 13, 5, 3);
        Enemylist.Enemlist.Add(Werewolf);
        string miracle = "0";

        Narrate("You run deeper into the forest trying to escape the wolfpack", 3000);
        Narrate("But you notice that the wolfpack stopped and didn't follow you further", 3000);
        Narrate("It looks like you were able to outrun them!", 3000);
        Narrate("You felt tired so you stopped by a tree to catch your breath", 3000);
        Narrate("But when you did so...", 3000);
        Narrate("You felt that something is watching you", 3000);
        Narrate("You look around and first you didn't see anything except dark silhouettes of trees around", 3000);
        Narrate("But then it suddenly struck you", 3000);
        Narrate("It was there. One of the tree silhouettes was looking odd", 3000);
        Narrate("You focus your eyes trying to identify it", 3000);
        Narrate("A powerful gust of the wind shakes the treetops covering the sun", 3000);
        Narrate("And for a moment a glimmer of light gives you just enough time", 3000);
        Narrate("To understand that it is not a tree...", 3000);
        Narrate(".", 1500);
        Narrate("..", 1500);
        Narrate("...", 1500);
        Thread.Sleep(2200);
        Narrate("It is a Werewolf.", 3000);
        int CharHP = Game.player.HP;
        var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Stick");
        int CharDmg = Game.player.Damage + (stick?.DamageBonus ?? 0);
        int EnemyDmg = Enemylist.Enemlist[3].EnemyDmg;
        int EnemyHP = Enemylist.Enemlist[3].EnemyHealth;
        int enemyini = Enemylist.Enemlist[3].EnemyINI;
        string enemytype = Enemylist.Enemlist[3].EnemyType;
        Combat fight3 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
        bool combat2 = fight3.Fight(enemytype, 5, enemyini, 3, Weaponlist.Weaponlists[0].Hitbonus);
        if (combat2 == true)
        {
            Console.WriteLine("How? Just How? THIS ONE WAS MADE TO KILL YOU");
            Console.WriteLine(""); //Add impossible win bonus
            Console.WriteLine("You won. I give up!");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
        else if (combat2 == false)
        {
            Console.WriteLine("You somewhow managed to escape. Frightened you run back to the road and find it by a miracle");
            Console.WriteLine("Werewolf doesnt follow you.");
            miracle = "3";

        }
        return miracle;

    }

    public static string PlotB1V1(string firstenc) //Mines
    {
        if (firstenc == "1")
            Narrate("You follow the road that leads you through the forest", 2500);
        Narrate("After some time you encounter a small railroad with empty minecarts", 2500);
        Narrate("Folowing the railroad you come to a stone hill with a mine entrance in the middle where the road leads", 2500);
        Narrate("Around the entrance you see piles of stone and broken mining equipment.", 2500);
        Narrate("You notice an old small pickaxe that can be used as a weapon", 2500);
        Narrate("Will you take it?", 2500);
        Console.WriteLine("");
        Console.WriteLine("1. Take");
        Console.WriteLine("2. Leave it");
        string uiactpickaxe = Console.ReadLine();
        if (uiactpickaxe == "1")
        {
            Console.WriteLine("You take the pickaxe and put it in your inventory");
            Thread.Sleep(2500);
            weapon smallpickaxe = new weapon("Small Pickaxe", 8, 3);
            Weaponlist.Weaponlists.Add(smallpickaxe);
            Console.WriteLine("You can now use it as a weapon");
            Thread.Sleep(2500);
        }
        else if (uiactpickaxe == "2")
        {
            Console.WriteLine("You leave the pickaxe where it is");
            Thread.Sleep(2500);
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
        bool exitmine = false;
        Narrate("You approach the mine entrance", 2500);
        Narrate("You need to decide if you want to go into the mine or not", 2500);
        Narrate("You can always come back later", 2500);

        do
        {
            Console.WriteLine("");
            Console.WriteLine("1. Enter the mine");
            Console.WriteLine("2. Go back to the crossroad");
            string? uinpdecidemine = Console.ReadLine();
            if (uinpdecidemine == "1")
            {
                Narrate("You enter the mine", 2500);
                string mines = PlotB1V1M1("1");

            }
            else if (uinpdecidemine == "2")
            {
                Narrate("You go back to the crossroad", 2500);
                exitmine = true;
                return "2"; //return to crossroad

            }
            else
            {
                Narrate("Invalid Input", 2500);
            }
        } while (!exitmine);

        return "";
    }

    public static string PlotB1V2(string firstenc) //Village
    {
        if (firstenc == "1")
        {
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("You decide to go to the village");
            Thread.Sleep(2500);
            Console.WriteLine("Seeing someone alive and not willing to kill you would be great");
            Thread.Sleep(2500);
            Console.WriteLine("You walk the path for some time and the forest start to fade away");
            Thread.Sleep(2500);
            Console.WriteLine("You can see a small village on the open field in the distance");
            Thread.Sleep(2500);
            Console.WriteLine("You notice mountains far away behind the village");
            Thread.Sleep(2500);
            Console.WriteLine("One of them looks different");
            Thread.Sleep(2500);
            Console.WriteLine("It is covered with unnaturaly blue clouds that storm with purple lightnings");
            Thread.Sleep(2500);
            Console.WriteLine("You cant hear them, but you feel the power the mountain radiates");
            Thread.Sleep(2500);
            Console.WriteLine("It scares you");
            Thread.Sleep(2500);
            Console.WriteLine("But you decide to go forward. You enter the village through the main road");
            Thread.Sleep(2500);
            Console.WriteLine("The guard post is empty on the village entrance");
            Thread.Sleep(2500);
            Console.WriteLine("You go towards the centre of the village and look around");
            Thread.Sleep(2500);
            Console.WriteLine("You notice people. They look at you with tired neutral eyes");
            Thread.Sleep(2500);
            Console.WriteLine("All of them are near their houses, some are busy with their housework");
            Thread.Sleep(2500);
            Console.WriteLine("And some just sit there and watch you");
        }
        bool villagexit = false;
        string villageexitdecis = "0";
        Thread.Sleep(2500);
        Console.WriteLine("You reach the centre of the village");
        Thread.Sleep(2500);
        Console.WriteLine("You have options where to go next!");
        Thread.Sleep(2500);
        do
        {
            Console.WriteLine("");
            Console.WriteLine("1. Shop ");
            Console.WriteLine("2. Tavern \"Miners delight\"");
            Console.WriteLine("3. Adventurers Guild");
            Console.WriteLine("4. Check stats");
            Console.WriteLine("5. Exit the village");
            Thread.Sleep(1000);
            Console.WriteLine("");
            string uiactdecisvillage = Console.ReadLine();
            if (uiactdecisvillage == "1") //shop make a new method aka instrument for shop
            {
                ShopVillage();
                villagexit = false;
            }
            else if (uiactdecisvillage == "2") // tavern
            {

            }
            else if (uiactdecisvillage == "3") // Guild **Make it later after finishing mines and 1 & 2 village lines.
            {

            }
            else if (uiactdecisvillage == "4")
            {
                Console.WriteLine(Game.player.PrintCharInfo());
                Thread.Sleep(2000);
                Console.WriteLine("");
                villagexit = false;
            }
            else if (uiactdecisvillage == "5") //exit village
            {
                Console.WriteLine("You decide to go out of the village and head back to the forest!");
                villageexitdecis = "1";
                villagexit = true;


            }
            else { Console.WriteLine("Invalid Input"); }

        } while (!villagexit);
        return villageexitdecis;
    }

    public static void ShopVillage()
    {
        bool exitshop = false;
        Console.WriteLine("You enter the shop");
        Thread.Sleep(2500);
        Console.WriteLine("The merchant greets you with tired eyes");
        Thread.Sleep(2500);
        Console.WriteLine("–Welcome to my shop.");
        Thread.Sleep(2500);
        Console.WriteLine("");
        do
        {
            Console.WriteLine("1. Trade");
            Console.WriteLine("2. Ask questions");
            Console.WriteLine("3. Exit the shop");
            Thread.Sleep(1000);
            Console.WriteLine("");
            string uiactshop1 = Console.ReadLine();
            if (uiactshop1 == "1")
            {
                Console.WriteLine("You approach the merchant.");
                Thread.Sleep(2500);
                Console.WriteLine("–What do you want to trade?");
                Thread.Sleep(2500);
                Trade.TradeSystem();
            }
            else if (uiactshop1 == "2")
            {
                Console.WriteLine("You ask the merchant about the village.");
                Thread.Sleep(2500);

            }
            else if (uiactshop1 == "3")
            {
                Console.WriteLine("You leave the shop.");
                Thread.Sleep(2500);
                exitshop = true;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        } while (!exitshop);
    }

    public static void Narrate(string text, int intervall)
    {
        Console.WriteLine(text);
        Thread.Sleep(intervall);
    }

    public static string PlotB1V1M1(string firstenc) //Mines
    {
        Random exprandomiser = new Random(0);
        int exprand = exprandomiser.Next(101);
        int exptries = 0;
        bool exitmine = false;
        if (firstenc == "1")
        {
            Enemy goblin = new Enemy("Goblin", 20, 100, 5, 5, 0, 4); //id 4
            Enemylist.Enemlist.Add(goblin);
            Narrate("You enter the mine and see that the path forward is lit by glowing crystals embedded in the walls.", 2500);
            Narrate("Its cold and quiet and it seems like there is no one inside", 2500);
            Narrate("You can hear your own footsteps echoing in the distance", 2500);
            Narrate("As you go forward you hear strange noises coming from deeper within the mine", 2500);

        }
        do
        {
            Narrate("You can go deeper into the mine or leave it", 2500);
            Narrate("What do you do?", 2500);
            Narrate("1. Explore the mine", 0);
            Narrate("2. Leave the mine", 0);
            string uinpdecismines = Console.ReadLine();
            if (uinpdecismines == "1")
            {
                exptries++;
                if (exptries > 4)
                {
                    Narrate("After exploring the mine for some time you find a new passage!", 2500);
                    Narrate("It looks like it leads deeper into the mine", 2500);
                    Narrate("You can go deeper or leave the mine", 2500);
                    do
                    {
                        Narrate("What do you do?", 2500);
                        Narrate("1. Go deeper into the mine", 0);
                        Narrate("2. Leave the mine", 0);
                        string uinpdecisdeep = Console.ReadLine();
                        if (uinpdecisdeep == "1")
                        {
                            Narrate("You go deeper into the mine", 2500);
                            Narrate("You enter the deep mines", 2500);
                            string plotb1v1m2 = PlotB1V1M2(firstenc);

                        }
                        else if (uinpdecisdeep == "2")
                        {
                            Narrate("You decide to leave the mine", 2500);
                            exitmine = true;
                        }
                        else
                        {
                            Narrate("Invalid Input", 2500);
                            continue;
                        }
                    } while (!exitmine);
                    return "2";
                }
                Narrate("You decide to explore the mine", 2500);
                if (exprand < 10 && exprand > 0)
                {
                    Narrate("You find a small chest with 50 gold inside", 2500);
                    Game.herogold.Gold += 50;
                    Narrate("You can continue exploring or leave the mine", 2500);
                }
                else if (exprand > 10 && exprand < 30)
                {
                    Narrate("You encounter a goblin!", 2500);
                    Narrate("The goblin attacks you!", 2500);
                    int CharHP = Game.player.HP;
                    Narrate("What weapon do you want to use?", 2500);
                    foreach (weapon wpn in Weaponlist.Weaponlists)
                    {
                        Narrate($"{wpn.WpnName} - Damage: {wpn.DamageBonus} Hitbonus: {wpn.Hitbonus}", 200);
                    }
                    var uinpweap = Console.ReadLine();
                    var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == uinpweap);
                    int CharDmg = Game.player.Damage + (stick?.DamageBonus ?? 0);
                    int EnemyDmg = Enemylist.Enemlist[4].EnemyDmg;
                    int EnemyHP = Enemylist.Enemlist[4].EnemyHealth;
                    int enemyini = Enemylist.Enemlist[4].EnemyINI;
                    string enemytype = Enemylist.Enemlist[4].EnemyType;
                    Combat fight3 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat2 = fight3.Fight(enemytype, 0, enemyini, 4, Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Small Pickaxe").Hitbonus);
                    if (combat2 == true)
                    {
                        Narrate("You defeated the goblin!", 2500);
                        Narrate("You can continue exploring or leave the mine", 2500);
                        Game.herogold.Gold += 20;
                    }
                    else
                    {
                        Narrate("You can leave the mine now", 2500);
                        exitmine = true;
                    }
                }
                else if (exprand > 30 && exprand < 70)
                {
                    Narrate("You find a small chest with 10 gold inside", 2500);
                    Game.herogold.Gold += 10;
                    Narrate("You can continue exploring or leave the mine", 2500);
                }
                else
                {
                    Narrate("You find nothing but dust and silence", 2500);
                }
            }
            else if (uinpdecismines == "2")
            {
                Narrate("You decide to leave the mine", 2500);
                exitmine = true;
            }
            else
            {
                Narrate("Invalid Input", 2500);
            }
        } while (!exitmine);
        return "0";
    }
    public static string PlotB1V1M2(string firstenc) // Deep Mines
    {
        if (firstenc == "1")
        {
            Enemy goblinvet = new Enemy("Goblin Veteran", 30, 150, 6, 10, 3, 5); //id 5
            Enemylist.Enemlist.Add(goblinvet);
            Narrate("The Deep mines were still covered with glowing crystals but the color changed from purple to blue", 2500);
        }
        Random exprandomiser = new Random();
        int exprand = exprandomiser.Next(101);
        int exptries = 0;
        bool exitdeep = false;
        Narrate("You go forward and you have an option to explore The Deep Mines", 2500);
        Narrate("What do you do?", 1000);
        do
        {
            Narrate("", 0);
            Narrate("1. Explore the Deep Mines", 0);
            Narrate("2. Leave the Deep Mines", 0);
            Narrate("", 0);
            string uinpdecismines2 = Console.ReadLine();
            if (uinpdecismines2 == "1")
            {
                exptries++;
                if (exptries > 3)
                {
                    Narrate("After exploring the Deep Mines for some time you find yet another passage", 2000);
                    Narrate("Do you want to go there?", 2000);
                    do
                    {
                        Narrate("1. Go deeper into the Deep Mines", 0);
                        Narrate("2. Leave the Deep Mines", 0);
                        string uinpdecisdeep = Console.ReadLine();
                        if (uinpdecisdeep == "1")
                        {
                            Narrate("You go deeper into the Deep Mines", 2500); //TODO later make the lost mines too
                            Narrate("You enter the Lost Mines", 2500);
                            break;
                        }
                        else if (uinpdecisdeep == "2")
                        {
                            Narrate("You decide to leave the Deep Mines", 2500);
                            exitdeep = true;
                            return "2"; //return to crossroad
                        }
                        else
                        {
                            Narrate("Invalid Input", 2500);
                            continue;
                        }
                    } while (!exitdeep);
                }
                Narrate("You decide to explore the Deep Mines", 2500);
                if (exprand < 10)
                {
                    Narrate("You find a hidden Gold chest!", 2000);
                    Narrate("You recieve 100 Gold!", 2000);
                    Game.herogold.Gold += 100;
                    continue;


                }
                else if (exprand > 10 && exprand < 33)
                {
                    Narrate("You find couple coins on the floor", 2000);
                    Narrate("You recieve 10 Gold", 2000);
                    Game.herogold.Gold += 10;
                    continue;

                }
                else if (exprand > 33 && exprand > 70)
                {
                    Narrate("You encounter a Goblin veteran!", 2000);
                    Narrate("He looks stronger than the ohters and is wielding a rusty iron sword!", 2000);
                    int CharHP = Game.player.HP;
                    var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Small Pickaxe");
                    int CharDmg = Game.player.Damage + (stick?.DamageBonus ?? 0);
                    int EnemyDmg = Enemylist.Enemlist[5].EnemyDmg;
                    int EnemyHP = Enemylist.Enemlist[5].EnemyHealth;
                    int enemyini = Enemylist.Enemlist[5].EnemyINI;
                    string enemytype = Enemylist.Enemlist[5].EnemyType;
                    Combat fight3 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                    bool combat2 = fight3.Fight(enemytype, 0, enemyini, 5, Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Small Pickaxe").Hitbonus);
                    if (combat2 == true)
                    {
                        Narrate("You defeated the goblin veteran!", 2500);
                        Narrate("You can continue exploring or leave the mine", 2500);
                        Game.herogold.Gold += 50;
                    }
                    else
                    {
                        Narrate("You can leave the mine now", 2500);
                        Narrate("Or explore more", 1500);
                    }

                }
                else
                {
                    Narrate("You find nothing!", 1500);

                }

                return "1";
            }
            else if (uinpdecismines2 == "2")
            {
                Narrate("You decide to leave the Deep Mines", 2500);
                exitdeep = true;
                return "2";
            }
            else
            {
                Narrate("Invalid Input", 2500);
            }
        } while (!exitdeep);
        return "";
    } 
    
public static string VillageShopAsk()
    {
        bool exitshopask = false;
        Narrate("You ask the merchant about the village", 2500);
        Narrate("–This village ", 2500);
        Narrate("–", 2500);
        Narrate("–", 2500);
        Narrate("–", 2500);
        Narrate("–", 2500);
        do
        {
            Narrate("", 0);
            Narrate("1. Ask about the mines", 0);
            Narrate("2. Ask about the village history", 0);
            Narrate("3. Leave the shop", 0);
            string uinpdecisshopask = Console.ReadLine();
            if (uinpdecisshopask == "1")
            {
                Narrate("The mines are dangerous, but we have no choice", 2500);
                Narrate("We need to mine crystals to survive", 2500);
                exitshopask = false;
            }
            else if (uinpdecisshopask == "2")
            {
                Narrate("The village was founded many years ago by miners who came here to mine crystals", 2500);
                Narrate("Since then, it has been passed down from generation to generation", 2500);
                exitshopask = false;
            }
            else if (uinpdecisshopask == "3")
            {
                Narrate("You leave the shop", 2500);
                exitshopask = true;
            }
            else
            {
                Narrate("Invalid Input", 2500);
            }
        } while (!exitshopask);

        return "";
    }










    public static string PlotB1V1M3(string firstenc) // Lost Mines
    {
        if (firstenc == "1")
        {
            Narrate("You enter the Lost Mines", 2500);
            Narrate("The crystals here are glowing with a strange purple light", 2500);
            Narrate("You feel a strange energy in the air", 2500);
            Narrate("You can hear distant sounds of mining and voices", 2500);
        }
        bool exitlost = false;
        Narrate("You can explore the Lost Mines or leave them", 2500);
        do
        {
            Narrate("", 0);
            Narrate("1. Explore the Lost Mines", 0);
            Narrate("2. Leave the Lost Mines", 0);
            string uinpdecislost = Console.ReadLine();
            if (uinpdecislost == "1")
            {
                Narrate("You decide to explore the Lost Mines", 2500);
                // TODO add exploration logic here
                return "1";
            }
            else if (uinpdecislost == "2")
            {
                Narrate("You decide to leave the Lost Mines", 2500);
                exitlost = true;
                return "2"; //return to crossroad
            }
            else
            {
                Narrate("Invalid Input", 2500);
            }
        } while (!exitlost);

        return "";
    }
}