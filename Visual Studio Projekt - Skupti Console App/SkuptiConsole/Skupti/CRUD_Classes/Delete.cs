using Skupti.Database_Classes;
using Skupti.Helper_Classes;

namespace Skupti.CRUD_Classes
{
    public class Delete
    {

        public static void DeleteOne(Product product)
        {
            var commandText = $"DELETE FROM Products Where ProductId = {product.ProductId}";

            SQLExecution.ExecuteCommand(commandText);
        }


    }
}
