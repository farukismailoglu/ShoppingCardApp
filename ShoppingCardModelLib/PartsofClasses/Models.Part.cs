using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Trendyol.ShoppingCart.Model
{
    public partial class Category
    {
        public Category()
        { }
        public Category(string title, decimal? ParantCategoryId = null)
        {
            Title = title;
            ParentCategoryId = ParentCategoryId;
        }
    }

    public partial class ParentCategory
    {
        public ParentCategory()
        { }

        public ParentCategory(string title) => Title = title;

    }

    public partial class Product {
        public Product()
        { }
        public Product(string title, decimal price, decimal categoryId)
        {
            Title = title;
            Price = price;
            CategoryId = categoryId;
        }
    }

    public partial class CartItem
    {
        public CartItem()
        { }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    public partial class Cart
    {
        public Cart() => Carts = new List<CartItem>();

    }

    public partial class Campaign
    {
        public Campaign()
        { }

        public Campaign(string title, int discount, decimal categoryId)
        {
            Title = title;
            Discount = discount;
            CategoryId = categoryId;
        }
    }

    public partial class Coupon
    {
        public Coupon()
        { }

        public Coupon(string title, decimal amountConstraint, decimal discount)
        {
            Title = title;
            AmountConstraint = amountConstraint;
            Discount = discount;
        }
    }

}
