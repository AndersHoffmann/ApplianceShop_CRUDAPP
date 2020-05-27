using ConsoleTables;
using Skupti.CRUD_Classes;

namespace Skupti.UI_Classes
{
    public class DisplayProducts
    {
        public static void DisplayAllProducts()
        {
            var allProducts = Read.ReadAllProducts();

            var table = new ConsoleTable("ID", "Produktnavn", "Pris", "Mærke", "Kategori");

            allProducts.ForEach(product => table.AddRow(product.ProductId, product.ProductName, product.Price,
                product.BrandId, product.SubCategoryId));

            table.Write(Format.Alternative);
        }

        public static void DisplayAllProductsAndTheirCategories()
        {
            var allProducts = Read.ReadAllProductsAndTheirCategories();

            var table = new ConsoleTable("ID", "Produktnavn", "Pris", "  ", "Mærke", "MærkeID", "  ", "Varegruppe", "VaregruppeID", "  ", "Kategori", "KategoriID");

            allProducts.ForEach(joinedProduct => table.AddRow(
                joinedProduct.ProductId,
                joinedProduct.ProductName,
                joinedProduct.Price,
                "  ",
                joinedProduct.BrandName,
                joinedProduct.BrandId,
                "  ",
                joinedProduct.SubCategoryName,
                joinedProduct.SubCategoryId,
                "  ",
                joinedProduct.CategoryName,
                joinedProduct.CategoryId));

            table.Write(Format.MarkDown);


        }

        public static void DisplayOneProduct(int productId)
        {
            var product = Read.ReadOneProduct(productId);

            var table = new ConsoleTable("ID", "Produktnavn", "Pris", "Mærke", "Kategori");

            table.AddRow(product.ProductId, product.ProductName, product.Price, product.BrandId, product.SubCategoryId);

            table.Write(Format.Alternative);
        }
    }

}