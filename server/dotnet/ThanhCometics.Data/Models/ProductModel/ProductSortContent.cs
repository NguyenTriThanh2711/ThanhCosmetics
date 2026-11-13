namespace ThanhCometics.Repository.Models.ProductModel
{
    public class ProductSortContent
    {
        public List<int> Brands { get; set; } = new List<int>();
        public List<int> Categories { get; set; } = new List<int>();
        public List<int> SkinTypes { get; set; } = new List<int>();
        public List<int> Functions { get; set; } = new List<int>();
        public List<int> Ingredients { get; set; } = new List<int>();
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
