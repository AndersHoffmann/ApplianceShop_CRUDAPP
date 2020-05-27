using Skupti.Helper_Classes;
using System;

namespace Skupti.UI_Classes
{
    public class MainMenuEmployee
    {
        public static void MainMenuChoiceOfAction()
        {

            Console.WriteLine("SKUPTI GIGANTEN - Vareadministration\n\n");

            Options.MainMenuEmployeeOptions();


            ConsoleKey choice;

            do
            {
                choice = Console.ReadKey(true).Key;

                if (choice == ConsoleKey.D1) ProductCRUD.ShowUI();

            } while (choice != ConsoleKey.D1);
        }
    }
}
