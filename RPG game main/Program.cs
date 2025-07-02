using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace RPG;

class Game
{
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
                    else { Console.WriteLine("Invalid Command!"); }
                } while (!exitmenu1);

            }
            else if (uinpmain == "1")
            {
                //Cutsczene.StartingSzene();
                //string uinpdecis1 = Cutsczene.PlotM1();
                string uinpdecis1 = "3";
                Cutsczene.PlotM2(uinpdecis1);



            }
            else { Console.WriteLine("Invalid Command!"); }
        } while (!exitgame);


    }
    



}
