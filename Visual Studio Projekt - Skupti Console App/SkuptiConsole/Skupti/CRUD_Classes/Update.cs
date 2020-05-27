
using Skupti.Database_Classes;
using Skupti.Helper_Classes;
using System.Collections.Generic;
using System.Linq;

namespace Skupti.CRUD_Classes
{
    public partial class Update // Bulk update prices 
    {
        public static List<Product> PriceAdjuster(List<Product> products, double pct)
        {
            pct /= 100;
            pct += 1;

            //Ændre pris ud fra procentsats - mindste ændring ud fra tallets størrelse
            products.ForEach(p => p.Price =
                p.Price < 100 && (p.Price - (p.Price * pct) > 5 || p.Price - (p.Price * pct) < -5) ? p.Price *= pct :
                p.Price >= 100 && p.Price < 200 && (p.Price - (p.Price * pct) > 25 || p.Price - (p.Price * pct) < -25) ? p.Price *= pct :
                p.Price >= 200 && p.Price < 500 && (p.Price - (p.Price * pct) > 50 || p.Price - (p.Price * pct) < -50) ? p.Price *= pct :
                p.Price >= 500 && (p.Price - (p.Price * pct) > 100 || p.Price - (p.Price * pct) < -100) ? p.Price *= pct :
                p.Price);

           
            //Sæt til til x99 hvis tal over 1000
            products.ForEach(p => p.Price =
                (p.Price % 100 != 99 && p.Price > 1000 ? p.Price -= (p.Price % 100 + 1) :
                    p.Price));
            //Sæt til x9
            products.ForEach(p => p.Price =
                p.Price % 10 != 0 ? (p.Price - p.Price % 10) + 9 :
                    p.Price);

            //Sæt til heltal
            products.ForEach(p => p.Price =
                (p.Price % 1 != 0 ? p.Price -= (p.Price % 1) :
                    p.Price));

            products.ForEach(p => p.Price += 0.95);

            return products;
        }

        public static void UpdateAllPrices(double pct) //General Usage
        {
            List<Product> products = Read.ReadAllProducts();

            List<Product> productsBeforeUpdate = products;

            PriceAdjuster(products, pct);

            for (int i = 0; i < productsBeforeUpdate.Count; i++)
            {
                UpdateOne(productsBeforeUpdate[i], products[i]);
            }
        }

        public static void UpdateAllPrices(List<Product> products, double pct) //For Specific Querying
        {
            List<Product> productsBeforeUpdate = products;

            PriceAdjuster(products, pct);

            for (int i = 0; i < productsBeforeUpdate.Count; i++)
            {
                UpdateOne(productsBeforeUpdate[i], products[i]);
            }
        }

        public static void UpdatePricesOneCategory(int SubcategoryId, double pct)
        {
            UpdateAllPrices(Read.ReadAllProducts()
                .Where(product => product.SubCategoryId == SubcategoryId).ToList(), pct);
        }

    }

    public partial class Update // Update Database Representational Classes 
    {
        public static void UpdateOne(Product product, Product newProduct) 
        {

            var commandText =
                $"UPDATE Products " +
                $"SET ProductName = '{newProduct.ProductName}', " +
                $"Price = ({newProduct.Price}), " +
                $"BrandId = {newProduct.BrandId}, " +
                $"SubCategoryId = {newProduct.SubCategoryId} " +
                $"WHERE ProductId = {product.ProductId}";


            SQLExecution.ExecuteCommand(commandText);

        }


    }



}
