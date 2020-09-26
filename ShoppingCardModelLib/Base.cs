using System;
using System.Collections.Generic;
using System.Text;

namespace Trendyol.ShoppingCart.Model
{
    public class Base
    {
        public decimal Id { get; set; }

    }

    public class BaseCategory : Base
    {
        public string Title { get; set; }

    }
}
