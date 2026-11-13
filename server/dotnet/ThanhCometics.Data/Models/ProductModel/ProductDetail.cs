namespace ThanhCometics.Repository.Models.ProductModel
{
    public class ProductDetail
    {
        public string Size { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public float Discount { get; set; }
    }
}
