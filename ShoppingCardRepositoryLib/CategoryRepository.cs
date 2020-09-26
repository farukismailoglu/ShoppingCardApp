using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository.Util;

namespace Trendyol.ShoppingCart.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories = new List<Category>();
        private static int ms_index;

        public CategoryRepository()
        { }
        public CategoryRepository(Category category) => _categories.Add(category);

        public void Add(Category category) {
            if (!ExitsByTitle(category.Title)) { 
                category.Id = ++ms_index;
                _categories.Add(category);
            }
            else
            {
                var updateCategory = FindById(category.Id);

                updateCategory.ParentCategoryId = category.ParentCategoryId;
                updateCategory.Products = category.Products;
            }
        }
        public IEnumerable<Category> All()
        {
            try
            {
                return _categories;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("All ", ex);
            }
        }

        public int Count()
        {
            try
            {
                return _categories.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Count ", ex);
            }
            
        }

        public void DeleteById(decimal id)
        {
            try
            {
                var c = FindById(id);

                if (c == null)
                    return;

                _categories.Remove(c);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DeleteById ", ex);
            }
            
        }

        public bool ExitsById(decimal id)
        {
            try
            {
                return FindById(id) != null;
            }
            catch (Exception ex)
            {

                throw new RepositoryException("ExitsById ", ex);
            }

        }

        public bool ExitsByTitle(string title)
        {
            try
            {
                return FindByTitle(title) != null;
            }
            catch (Exception ex)
            {

                throw new RepositoryException("ExitsByTitle ", ex);
            }

        }

        public Category FindById(decimal id)
        {
            try
            {
                return _categories.FirstOrDefault(c => c.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new RepositoryException("FindById ", ex);
            }

        }

        public Category FindByTitle(string title)
        {
            try
            {
                return _categories.FirstOrDefault(c => c.Title.Equals(title));
            }
            catch (Exception ex)
            {

                throw new RepositoryException("FindByTitle ", ex);
            }

        }
    }
}
