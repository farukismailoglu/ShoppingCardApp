using System;
using System.Collections.Generic;
using System.Text;
using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Service
{
    public interface IParentCategoryService : IBaseService
    {
        public void Add(ParentCategory parentCategory);

        public void Delete(decimal id);

        public void SearchByTitle(string title);
    }
}
