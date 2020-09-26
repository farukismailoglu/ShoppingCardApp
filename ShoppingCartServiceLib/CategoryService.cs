using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service.Util;

namespace Trendyol.ShoppingCart.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryService categoryService) => _categoryRepository = categoryService;

        public void Add(Category category)
        {
            try
            {
                _categoryRepository.Add(category);
            }
            catch (ServiceException ex)
            {
                throw new ServiceException("Add", ex);
            } 
        }

        public void DeleteCategory(decimal id)
        {
            try
            {
                _categoryRepository.DeleteById(id);
            }
            catch (ServiceException ex)
            {
                throw  new ServiceException("DeleteById", ex);
            }
        }

        public Category SearchById(decimal id)
        {
            try
            {
                return  _categoryRepository.FindById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("SearchById", ex);
            }
        }
        public Category SearchByTitle(string title)
        {
            try
            {
                return _categoryRepository.FindByTitle(title);
            }
            catch (Exception ex)
            {
                throw new ServiceException("SearchByTitle", ex);
            }
        }
        public bool ExitsById(decimal id)
        {
            try
            {
                return _categoryRepository.ExitsById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("ExitsById", ex);
            }
        }

        public  bool ExitsByTitle(string title)
        {
            try
            {
                return _categoryRepository.ExitsByTitle(title);
            }
            catch (Exception ex)
            {
                throw new ServiceException("ExitsByTitle", ex);
            }
        }
    }
}
