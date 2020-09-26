using System.ComponentModel;
using System.Reflection;

namespace Trendyol.ShoppingCart.Model
{
    public partial class Product : Base
    {
        public string Title { get; set; }

        public decimal Price { get; set; }
        public decimal CategoryId { get; set; }

        public Category Category { get; set; }      

    }
}
