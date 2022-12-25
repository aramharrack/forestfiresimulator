using System;

namespace forestfiresimulator
{
    class MenuOptions
    {
        public void MainMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("\tFOREST FIRE SIMULATOR");
            Console.WriteLine("****************************************\n");
            Console.WriteLine("\tMain Menu");
            Console.WriteLine("1. Display the forest.");
            Console.WriteLine("2. Set central tree to burn.");
            Console.WriteLine("3. Run the simulation.");
            Console.WriteLine("4. Reburn the forest to completion.");
            Console.WriteLine("5. Set central tree and burn till completion (Options 2-4).");
            Console.WriteLine("6. Reset the forest.");
            Console.WriteLine("7. Check iterations the forest burned.");
            Console.Write("\nSelect a listed option or enter 0 to exit: ");
        }

        public void ReturnToMain()
        {
            Console.Write("Press [ENTER] to return to Main Menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
