using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace RPG;

class Game
{
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
                        Character newChar = Character.Creation();
                        Console.WriteLine(newChar.PrintCharInfo());
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
                if (CharacterList.Charlist.Count == 0)
                {
                    Console.WriteLine("You need to create a character first!");
                    Thread.Sleep(1500);
                    exitgame = false;
                    continue;
                }
                else
                {
                    bool plotloop1 = true;
                    Cutsczene.StartingSzene();
                    string uinpdecis1 = Cutsczene.PlotM1();
                    string uactfight1 = Cutsczene.PlotM2(uinpdecis1);
                    string uactdecis2 = Cutsczene.PlotM3(uactfight1);
                    do
                    {
                        if (uactdecis2 == "1")
                        {
                            string plotb2end = Cutsczene.PlotB2V1("1");
                            if (plotb2end == "2")
                            {
                                uactdecis2 = plotb2end;
                                plotloop1 = false;
                                continue;
                            }
                            else if (plotb2end == "3")
                            {
                                uactdecis2 = plotb2end;
                                plotloop1 = false;
                                continue;
                            }
                        }
                        else if (uactdecis2 == "2")
                        {
                            string decision1 = Cutsczene.PlotB1();//1 - mines // 2 - village

                        }
                        else if (uactdecis2 == "3")
                        {
                            string decision1 = Cutsczene.PlotB2V2(); //DOUBLE CHECK THE DECISIONS NOT SURE IF THEY HAVE RIGHT OUTCOMES!!!!!***


                        }
                    } while (!plotloop1);
                }



            }
            else { Console.WriteLine("Invalid Command!");Thread.Sleep(500); }
        } while (!exitgame);


    }
    



}
