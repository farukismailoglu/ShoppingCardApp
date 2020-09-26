using System;
using System.Collections.Generic;
using System.Text;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service.Util;

namespace Trendyol.ShoppingCart.Service
{
    public class ParentCategoryService : IParentCategoryService
    {
        private readonly IParentCategoryRepository _parentCategoryRepository;

        public ParentCategoryService(IParentCategoryRepository parentCategoryRepository) => _parentCategoryRepository = parentCategoryRepository;

        public void Add(ParentCategory parentCategory)
        {
            try
            {
                _parentCategoryRepository.Add(parentCategory);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Add", ex);
            }
            
        }

        public void Delete(decimal id)
        {
            try
            {
                if(_parentCategoryRepository.ExitsById(id))
                    _parentCategoryRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Delete", ex);
            }
        }

        public void SearchByTitle(string title)
        {
            try
            {
                _parentCategoryRepository.FindByTitle(title);
            }
            catch (Exception ex)
            {
                throw new ServiceException("SearchByTitle", ex);
            }
        }

    }
}
