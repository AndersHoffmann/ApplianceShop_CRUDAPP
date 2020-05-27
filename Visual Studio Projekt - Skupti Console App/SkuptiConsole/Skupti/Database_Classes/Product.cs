namespace Skupti.Database_Classes
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
