using System;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service.Util;

namespace Trendyol.ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;


        public void Add(Product product)
        {
            try
            {
                _productRepository.Add(product);
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
                if(_productRepository.ExitsById(id))
                {
                    _productRepository.DeleteById(id);
                }
            }
            catch (Exception ex)
            {

                throw new ServiceException("DeleteProduct", ex);
            }
        }

        public Product SearchByTitle(string title)
        {
            try
            {
                return _productRepository.FindByTitle(title);
            }
            catch (Exception ex)
            {
                throw new ServiceException("SearchByTitle", ex);
            }
        }
    }
}
