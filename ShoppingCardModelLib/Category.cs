using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Trendyol.ShoppingCart.Model
{
    public partial class Category : BaseCategory
    {
        public decimal? ParentCategoryId { get; set; }
        public ICollection<Product> Products { get; set; }       

    }
    
    public partial class ParentCategory : BaseCategory
    { }



}
