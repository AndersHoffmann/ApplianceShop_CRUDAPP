namespace Skupti.Database_Classes
{
    public class JoinedProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string SubCategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
