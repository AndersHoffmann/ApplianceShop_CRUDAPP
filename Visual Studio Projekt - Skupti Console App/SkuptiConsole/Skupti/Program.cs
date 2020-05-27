using Skupti.CRUD_Classes;
using Skupti.Database_Classes;
using Skupti.Helper_Classes;
using Skupti.UI_Classes;
using System;


namespace Skupti
{
    class Program
    {
        static void Main(string[] args)
        {

            CultureSetupClass.SetupCorrectCulture();

            Console.SetWindowSize(170, 47);
            Console.SetWindowPosition(0, 0);

            MainMenuEmployee.MainMenuChoiceOfAction();

            Console.ReadKey();

        }
    }
}
