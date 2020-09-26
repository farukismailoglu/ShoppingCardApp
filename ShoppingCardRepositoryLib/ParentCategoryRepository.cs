using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository.Util;

namespace Trendyol.ShoppingCart.Repository
{
    public class ParentCategoryRepository : IParentCategoryRepository
    {
        private static List<ParentCategory> _parentCategories = new List<ParentCategory>();
        private static int ms_index;

        public ParentCategoryRepository()
        { }

        public ParentCategoryRepository(ParentCategory parentCategory) => _parentCategories.Add(parentCategory);

        public void Add(ParentCategory parentCategory)
        {
            try
            {
                if (!ExitsByTitle(parentCategory.Title))
                {
                    parentCategory.Id = ++ms_index;
                    _parentCategories.Add(parentCategory);
                }
            }
            catch (Exception ex)
            { 
                throw new RepositoryException("Add", ex);
            }
            
        }

        public void DeleteById(decimal id)
        {
            try
            {
                var p = FindById(id);

                if (p == null)
                    return;

                _parentCategories.Remove(p);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DeleteById", ex);
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
                throw new RepositoryException("ExitsById", ex);
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

                throw new RepositoryException("ExitsByTitle", ex);
            }
            
        }

        public ParentCategory FindById(decimal id)
        {
            try
            {
                return _parentCategories.FirstOrDefault(pc => pc.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindById", ex);
                
            }
        }

        public ParentCategory FindByTitle(string title)
        {
            try
            {
                return _parentCategories.FirstOrDefault(pc => pc.Title == title);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindByTitle", ex);
            }
            
        }

        public int Count()
        {
            try
            {
                return _parentCategories.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Count", ex);
            }
            
        }

        public void Clear()
        {
            try
            {
                _parentCategories.Clear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Clear", ex);
            }

        }
    }
}
