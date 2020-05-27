using Skupti.Database_Classes;
using Skupti.Helper_Classes;

namespace Skupti.CRUD_Classes
{
    public class Create
    {
        public static void CreateOne(Product product)
        {

            string commandText = (
                $"INSERT INTO Products" +
                $"(ProductName, Price, BrandId, SubCategoryId) " +
                $"VALUES ('{product.ProductName}','{product.Price}','{product.BrandId}','{product.SubCategoryId}')");

            SQLExecution.ExecuteCommand(commandText);
        }


    }
}
