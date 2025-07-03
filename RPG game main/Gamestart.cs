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
        Console.WriteLine("Only the sound of wind in the trees are disturbing the silence");
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
                Thread.Sleep(1000);
                Console.WriteLine("You hear nothing except the sounds of wind somewhere above");
                Thread.Sleep(2000);
                Console.WriteLine("You feel that this forest it not so simple as it looks. You decide to stay sharp");
                Thread.Sleep(4000);
                Console.WriteLine("");
                check1 = false;
                if (chrbonuscheck3 == 0)
                {
                    CharacterList.Charlist[0].Initiative = CharacterList.Charlist[0].Initiative + 4;
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
                    Thread.Sleep(1000);
                    Console.WriteLine("You have found a stick. ");
                    Thread.Sleep(2000);
                    Console.WriteLine("Its heavy and pretty strong so you decide to take it");
                    Console.WriteLine("");
                    Thread.Sleep(1500);
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
        Enemy rat = new Enemy("Rat", 9, 30, 3, 10,0, 0);
        Enemylist.Enemlist.Add(rat);
        Enemy wolf = new Enemy("Wolf", 15, 60, 5, 12,1, 1);
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
                    int CharDmg = CharacterList.Charlist[0].Damage + Weaponlist.Weaponlists[0].DmgAdd(); //TODO later: add class weapons and auto add properties
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
        Console.WriteLine("You decide to strand in the forest in case there is an ambush on the road");
        Thread.Sleep(4000);
        Console.WriteLine("You go deeper and deeper into the darkness");
        Thread.Sleep(3000);
        Console.WriteLine("You hear strange sounds somewhere deep in the forest");
        Thread.Sleep(3000);
        Console.WriteLine("Suddenly the bushes in front of you start to shake");
        Thread.Sleep(3000);
        Console.WriteLine("A gray wolf walks out of them and looks right at you");
        Thread.Sleep(3000);
        Console.WriteLine("There is some distance between you but you are certain that running away from this one is not an option");
        Thread.Sleep(5000);
        Console.WriteLine("The wolf howls and you hear distant answer of his brothers.");
        Thread.Sleep(3000);
        Console.WriteLine("What will you do?");
        Thread.Sleep(1000);
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
                int CharHP = CharacterList.Charlist[0].HP;
                var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Stick");
                int CharDmg = CharacterList.Charlist[0].Damage + (stick?.DamageBonus ?? 0);
                int EnemyDmg = Enemylist.Enemlist[1].EnemyDmg;
                int EnemyHP = Enemylist.Enemlist[1].EnemyHealth;
                int enemyini = Enemylist.Enemlist[1].EnemyINI;
                string enemytype = Enemylist.Enemlist[1].EnemyType;
                Combat fight2 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
                bool combat2 = fight2.Fight(enemytype, 0, enemyini, 1, 0);
                fight2over = combat2;
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
                string charinfo = CharacterList.Charlist[0].PrintCharInfo();
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
        Enemy wolfpack = new Enemy("Wolfpack", 30, 200, 60, 7,3, 2); //id 2
        Enemylist.Enemlist.Add(wolfpack);
        string plotB2V1end = "0";
        Console.WriteLine("After defeating the wolf you hear howling that is coming towards you from the deep forest ");
        Thread.Sleep(4000);
        Console.WriteLine("You still have a chance to try and escape the szene until they found you");
        Thread.Sleep(4000);
        Console.WriteLine("What do you do?");
        Thread.Sleep(2500);
        Console.WriteLine("");
        Console.WriteLine("1. Run back to the road");
        Console.WriteLine("2. Stay and fight");
        Console.WriteLine("3. Run in another direction deeper into the forest");
        Console.WriteLine("");
        string uinpdesiforest2 = Console.ReadLine();
        if (uinpdesiforest2 == "1")
        {
            plotB2V1end = "2";
        }
        else if (uinpdesiforest2 == "2")
        {
            Console.WriteLine("You decided to stay and face them!");
            Thread.Sleep(3500);
            Console.WriteLine("A wolfpack emerges from the darkness");
            Thread.Sleep(3500);
            Console.WriteLine("There is a lot of them and you feel shivers crawling down your spine");
            Thread.Sleep(3500);
            Console.WriteLine("You notice that you are surrounded and there is no way to escape");
            Thread.Sleep(3500);
            Console.WriteLine("Good Luck...");
            Thread.Sleep(2500);
            int CharHP = CharacterList.Charlist[0].HP;
            var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Stick");
            int CharDmg = CharacterList.Charlist[0].Damage + (stick?.DamageBonus ?? 0);
            int EnemyDmg = Enemylist.Enemlist[2].EnemyDmg;
            int EnemyHP = Enemylist.Enemlist[2].EnemyHealth;
            int enemyini = Enemylist.Enemlist[2].EnemyINI;
            string enemytype = Enemylist.Enemlist[2].EnemyType;
            Combat fight3 = new Combat(EnemyHP, CharHP, EnemyDmg, CharDmg);
            bool combat2 = fight3.Fight(enemytype, 0, enemyini, 2, Weaponlist.Weaponlists[0].Hitbonus);
            Thread.Sleep(3000);
            Console.WriteLine("You have managed to kill them all");
            Thread.Sleep(2000);
            Console.WriteLine("You recieved 150 gold"); // todo add escape branch for plot in this battle
            Game.herogold.Gold += 150;
            Console.WriteLine("You decide to go back to the road. Who knows who else can hide in this forest");
            Thread.Sleep(3000);
            Console.WriteLine("Or what else...");
            Thread.Sleep(2000);
            plotB2V1end = "1";


        }
        else if (uinpdesiforest2 == "3")
        {
            plotB2V1end = "3";

        }
        return plotB2V1end;
    }

    public static string PlotB2V2() //forward into the forest
    {
        Enemy Werewolf = new Enemy("Werewolf", 50, 400, 40, 13, 5, 3);
        Enemylist.Enemlist.Add(Werewolf);
        string miracle = "0";

        Console.WriteLine("You were running deeper into the forest hoping they wont catch up on you");
        Thread.Sleep(3000);
        Console.WriteLine("But you notice that the wolfpack stoped and didnt folow you further");
        Thread.Sleep(3000);
        Console.WriteLine("It looks like you was able to outran them!");
        Thread.Sleep(3000);
        Console.WriteLine("You felt tired so you stoped by a tree to catch your breath");
        Thread.Sleep(3000);
        Console.WriteLine("But when you did so...");
        Thread.Sleep(3000);
        Console.WriteLine("You felt that something is watching you ");
        Thread.Sleep(3000);
        Console.WriteLine("You look around and first you didnt see anything except dark silhouettes of trees around");
        Thread.Sleep(3000);
        Console.WriteLine("But then it suddenly struck you");
        Thread.Sleep(3000);
        Console.WriteLine("It was there. One of the tree silhouettes was looking odd");
        Thread.Sleep(3000);
        Console.WriteLine("You focus your eyes trying to identify it");
        Thread.Sleep(3000);
        Console.WriteLine("A powerful gust of the wind shakes the treetops covering the sun");
        Thread.Sleep(3000);
        Console.WriteLine("And for a moment a glimmer of light gives you just enogh time");
        Thread.Sleep(3000);
        Console.WriteLine("To understand that it is not a tree...");
        Thread.Sleep(1500);
        Console.WriteLine(".");
        Thread.Sleep(1500);
        Console.WriteLine("..");
        Thread.Sleep(1500);
        Console.WriteLine("...");
        Thread.Sleep(2200);
        Console.WriteLine("It is a Werewolf.");
        Thread.Sleep(3000);
        int CharHP = CharacterList.Charlist[0].HP;
        var stick = Weaponlist.Weaponlists.FirstOrDefault(item => item.WpnName == "Stick");
        int CharDmg = CharacterList.Charlist[0].Damage + (stick?.DamageBonus ?? 0);
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
        }
        else if (combat2 == false)
        {
            Console.WriteLine("You somewhow managed to escape. Frightened you run back to the road and find it by a miracle");
            Console.WriteLine("Werewolf doesnt follow you.");
            miracle = "1";

        }
        return miracle;

    }
}