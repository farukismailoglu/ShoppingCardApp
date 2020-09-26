using System;
using System.Collections.Generic;
using System.Text;

namespace Trendyol.ShoppingCart.Model
{
    public partial class CartItem : Base
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }

    public partial class Cart : Base
    {
        public List<CartItem> Carts { get; set; }

    }
}
