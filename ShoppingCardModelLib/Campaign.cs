namespace Trendyol.ShoppingCart.Model
{
    public partial class Campaign : Base
    {
        public string Title { get; set; }
        public int Discount { get; set; }

        public decimal CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
