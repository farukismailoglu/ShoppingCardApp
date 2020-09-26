using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public class ParentCategoryRepository : IParentCategoryRepository
    {
        private static List<ParentCategory> _parentCategories = new List<ParentCategory>();
        private static int ms_index;

        public ParentCategoryRepository()
        { }

        public ParentCategoryRepository(ParentCategory parentCategory)
        {
            _parentCategories.Add(parentCategory);
        }

        public void Add(ParentCategory parentCategory)
        {
            if (!ExitsByTitle(parentCategory.Title)) {
                parentCategory.Id = ++ms_index;
                _parentCategories.Add(parentCategory);
            }
        }

        public void DeleteById(decimal id)
        {
            var p = FindById(id);

            if (p == null)
                return;

            _parentCategories.Remove(p);
        }

        public bool ExitsById(decimal id) => FindById(id) != null;

        public bool ExitsByTitle(string title) => FindByTitle(title) != null;

        public ParentCategory FindById(decimal id) => _parentCategories.FirstOrDefault(pc => pc.Id == id);

        public ParentCategory FindByTitle(string title) => _parentCategories.FirstOrDefault(pc => pc.Title == title);

        public int Count() => _parentCategories.Count();

        public void Clear() => _parentCategories.Clear();
    }
}
