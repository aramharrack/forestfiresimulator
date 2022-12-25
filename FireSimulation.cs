using System;

namespace forestfiresimulator
{
    class FireSimulation
    {
        static void Main(string[] args)
        {
            ForestGenerator forestGen = new ForestGenerator();
            ForestFireSimulation simulation = new ForestFireSimulation();
            MenuOptions menu = new MenuOptions();

            string userInput;
            int selection;
            int[,] forest = new int[21, 21];

            //get data from file and populate 2D Array
            forestGen.GetFile(forest);

            menu.MainMenu();
            userInput = Console.ReadLine();
            selection = int.Parse(userInput);

            try
            {
                while (selection != 0)
                {
                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("\nDisplay the forest of trees.\n");
                            simulation.DisplayGrid(forest, forestGen.GetRow(), forestGen.GetColumn());
                            menu.ReturnToMain();
                            break;
                        case 2:
                            Console.WriteLine("\nSetting central tree to burn.\n");
                            simulation.StartBurn(forest, forestGen.GetRow(), forestGen.GetColumn());
                            menu.ReturnToMain();
                            break;
                        case 3:
                            Console.WriteLine("\nRunning the simulation.\n");
                            simulation.ApplyBurn(forest, forestGen.GetRow(), forestGen.GetColumn(), 0);
                            menu.ReturnToMain();
                            break;
                        case 4:
                            Console.WriteLine("\nReburning the forest.\n");
                            simulation.ApplyBurn(forest, forestGen.GetRow(), forestGen.GetColumn(), 1);
                            menu.ReturnToMain();
                            break;
                        case 5:
                            Console.WriteLine("\nBurning the forest automatically.\n");
                            simulation.ApplyBurn(forest, forestGen.GetRow(), forestGen.GetColumn(), 2);
                            menu.ReturnToMain();
                            break;
                        case 6:
                            Console.WriteLine("\nResetting the forest.\n");
                            simulation.ResetForest(forest, forestGen.GetRow(), forestGen.GetColumn());//stuff to reset
                            menu.ReturnToMain();
                            break;
                        case 7:
                            Console.WriteLine("\nChecking iterations the forest burned.\n");
                            Console.WriteLine("The forest has burned {0} times.", simulation.GetBurnCount());
                            menu.ReturnToMain();
                            break;
                        default:
                            Console.WriteLine("\nInvalid selection!\n");
                            menu.ReturnToMain();
                            break;
                    }

                    menu.MainMenu();
                    userInput = Console.ReadLine();
                    selection = int.Parse(userInput);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.Message);
            }
        }//close main method
    }//close class
}//close namespace
