using System;
using System.Collections.Generic;
using System.Text;

namespace Trendyol.ShoppingCart.Model
{
    public partial class Coupon : Base
    {
        public string Title { get; set; }
        public decimal AmountConstraint { get; set; }
        public decimal Discount { get; set; }
    }
}
