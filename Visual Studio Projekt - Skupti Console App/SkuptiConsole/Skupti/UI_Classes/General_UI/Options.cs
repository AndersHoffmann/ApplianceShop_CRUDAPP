using ConsoleTables;
using System;

namespace Skupti.Helper_Classes
{
    public class Options
    {
        public static void MainMenuEmployeeOptions()
        {
            var table = new ConsoleTable("Muligheder", "Shortcut");

            table.AddRow("Produkter CRUD", "Tryk 1");

            table.Write(Format.MarkDown);

            Console.WriteLine();
        }
        public static void ProductCrudOptions()
        {
            var table = new ConsoleTable("Muligheder", "Shortcut");

            table.AddRow("Opret Produkt", "Tryk 1");
            table.AddRow("Rediger Produkt", "Tryk 2");
            table.AddRow("Slet Produkt", "Tryk 3");
            table.AddRow("Prisændringer", "Tryk 4");

            table.Write(Format.MarkDown);

            Console.WriteLine();
        }
        public static void PriceChangesOptions()
        {
            var table = new ConsoleTable("Mulighed", "Shortcut");

            table.AddRow("Alle Produkter", "Tryk 1");
            table.AddRow("En Varegruppe", "Tryk 2");

            table.Write(Format.MarkDown);

            Console.WriteLine();
        }
    }
}
