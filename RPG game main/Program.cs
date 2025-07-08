using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace RPG;

class Game
{
    public static Character player = null;
    
    public static Money herogold = new Money(0);
    
    public List<Character> charinfo = new List<Character>();
    public List<Enemy> enemyinfo = new List<Enemy>();

    public static void Main(string[] args)
    {
         

        bool exitgame = false;
        do
        {

            exitgame = false;
            bool exitmenu1 = false;
            string uinpmain;
            uinpmain = Menu.MainMenu();
            Character character;
            if (uinpmain == "3")
            {
                Exit.Exitopt();
            }
            else if (uinpmain == "2")
            {
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("1. Create New Character");
                    Console.WriteLine("2. Return to Main Menu ");
                    string uinpCreation = Console.ReadLine();
                    if (uinpCreation == "1")
                    {
                        player = Character.Creation();
                        Console.WriteLine(player.PrintCharInfo());
                        exitmenu1 = false;
                    }
                    else if (uinpCreation == "2")
                    {
                        exitmenu1 = true;
                        continue;
                    }
                    else { Console.WriteLine("Invalid Command!"); Thread.Sleep(500); }
                } while (!exitmenu1);

            }
            else if (uinpmain == "1")
            {
                if (Game.player == null)
                {
                    Console.WriteLine("You need to create a character first!");
                    Thread.Sleep(1500);
                    exitgame = false;
                    continue;
                }
                else
                {
                    bool plotloop1 = true;
                   
                    bool plotloop2 = true;
                    Cutsczene.StartingSzene();
                    string uinpdecis1 = Cutsczene.PlotM1();
                    string uactfight1 = Cutsczene.PlotM2(uinpdecis1);
                    string uactdecis2 = Cutsczene.PlotM3(uactfight1);
                    
                    string uactdecis3 = "2";
                    do
                     {
                         if (uactdecis2 == "1")
                         {
                             string plotb2end = Cutsczene.PlotB2V1("1");
                             uactdecis2 = plotb2end;
                             plotloop1 = false;
                         }
                         else if (uactdecis2 == "2")
                         {
                             uactdecis3 = Cutsczene.PlotB2V2(); //DOUBLE CHECK THE DECISIONS NOT SURE IF THEY HAVE RIGHT OUTCOMES!!!!!***
                             uactdecis2 = uactdecis3;
                             plotloop1 = false;


                         }
                         else if (uactdecis2 == "3")
                         {
                             uactdecis3 = Cutsczene.PlotB1();//1 - mines // 2 - Village
                             plotloop1 = true;




                         }
                     } while (!plotloop1);
                    
                    do
                    {



                        if (uactdecis3 == "1") // mines
                        {
                            Cutsczene.PlotB1V1("2");
                            uactdecis3 = "2";
                            plotloop2 = false;


                        }
                        else if (uactdecis3 == "2") //village
                        {
                            Cutsczene.PlotB1V2("2");
                            uactdecis3 = "1";
                            plotloop2 = false;

                        }
                    } while (!plotloop2);
                }



            }
            else { Console.WriteLine("Invalid Command!"); Thread.Sleep(500); }
        } while (!exitgame);


    }
    



}
