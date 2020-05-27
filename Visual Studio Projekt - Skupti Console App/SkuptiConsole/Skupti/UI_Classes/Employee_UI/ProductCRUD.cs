
using Skupti.CRUD_Classes;
using Skupti.Database_Classes;
using Skupti.Helper_Classes;
using System;

namespace Skupti.UI_Classes
{
    public class ProductCRUD
    {
        public static void ShowUI()
        {
            Console.Clear();

            DisplayProducts.DisplayAllProductsAndTheirCategories();

            Options.ProductCrudOptions();

            ConsoleKey choice;

            do
            {
                choice = Console.ReadKey(true).Key;

                switch (choice)
                {
                    case ConsoleKey.D1: ProductCreate(); break;
                    case ConsoleKey.D2: ProductUpdate(); break;
                    case ConsoleKey.D3: ProductDelete(); break;
                    case ConsoleKey.D4: ProductPrices(); break;
                }
            }

            while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2 && choice != ConsoleKey.D3 && choice != ConsoleKey.D4);

        }

        public static void ProductCreate()
        {
            Product tempProduct = new Product();

            Console.WriteLine();

            Console.Write("Indtast Produktnavn:  "); tempProduct.ProductName = Console.ReadLine();

            Console.Write("Indtast Pris:  "); tempProduct.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast MærkeID:  "); tempProduct.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Indtast VaregruppeID:  "); tempProduct.SubCategoryId = Convert.ToInt32(Console.ReadLine());

            Create.CreateOne(tempProduct);

            ShowUI();
        }
        private static void ProductUpdate()
        {
            Console.Write("Vælg produktID for produktet som skal ændres:  ");
            int produktId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nuværende info:  ");
            DisplayProducts.DisplayOneProduct(produktId);

            Product tempProduct = new Product();
            Console.Write("Indtast nyt Produktnavn:  ");
            tempProduct.ProductName = Console.ReadLine();

            Console.Write("Indtast ny Pris:  ");
            tempProduct.Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Indtast ny MærkeID:  ");
            tempProduct.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast ny VaregruppeID:  ");
            tempProduct.SubCategoryId = Convert.ToInt32(Console.ReadLine());

            if (Confirm())
            {
                Update.UpdateOne(Read.ReadOneProduct(produktId), tempProduct);
            }

            ShowUI();

        }

        public static void ProductDelete()
        {
            Console.WriteLine();
            Console.Write("Indtast produktID der skal slettes:  "); int produktId = Convert.ToInt32(Console.ReadLine());

            DisplayProducts.DisplayOneProduct(produktId);
            Console.WriteLine("Sikker på at du vil slette ovenstående?");
            if (Confirm())
            {
                Delete.DeleteOne(Read.ReadOneProduct(produktId));
            }
            ShowUI();
        }

        private static void ProductPrices()
        {

            Console.WriteLine("Hvad skal der ændres priser for?");
            Console.WriteLine();
            Options.PriceChangesOptions();

            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;

                switch (choice)
                {
                    case ConsoleKey.D1:

                        Console.Write("Indtast procentsats for prisopdatering:  ");
                        Update.UpdateAllPrices(Convert.ToDouble(Console.ReadLine()));

                        ShowUI();
                        break;
                    case ConsoleKey.D2:

                        Console.Write("Indtast VaregruppeID: "); int vareGruppeId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Indtast procentsats for prisopdatering:  "); double procentSats = Convert.ToDouble(Console.ReadLine());

                        Update.UpdatePricesOneCategory(vareGruppeId, procentSats);

                        ShowUI();
                        break;
                }
            }

            while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2);

            ShowUI();
        }

        public static bool Confirm()
        {

            Console.WriteLine("Tryk Y for at bekræfte, eller N for at afbryde");
            ConsoleKey choice;

            do
            {
                choice = Console.ReadKey(true).Key;

                switch (choice)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }
            }

            while (choice != ConsoleKey.Y && choice != ConsoleKey.N);

            return false;
        }

    }

}
