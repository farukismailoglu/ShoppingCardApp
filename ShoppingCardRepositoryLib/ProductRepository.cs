using System;
using System.Collections.Generic;
using System.Linq;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository.Util;

namespace Trendyol.ShoppingCart.Repository
{
    public class ProductRepository : IProductRepository
    {
        public static List<Product> _products = new List<Product>();
        public static int ms_index ;

        public ProductRepository() 
        { }
        public ProductRepository(Product product) => _products.Add(product);
        
        public void Add(Product product)
        {
            try
            {
                if (!ExitsByTitle(product.Title)) { 
                    product.Id = ++ms_index;
                    _products.Add(product);
                }
                else
                {
                    var updateProduct = FindByTitle(product.Title);
                    updateProduct.Price = product.Price;
                    updateProduct.CategoryId = product.CategoryId;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Add", ex);
            }

        }

        public IEnumerable<Product> All()
        {
            try
            {
                return _products;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Add", ex);
            }
            
        }

        public int Count()
        {
            try
            {
                return _products.Count();
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
                _products.Remove(_products.FirstOrDefault(p => p.Id == id));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Add", ex);
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
                throw new RepositoryException("Add", ex);
            }
        }

        public Product FindById(decimal id)
        {
            try
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Add", ex);
            }
        }

        public Product FindByTitle(string title)
        {
            try
            {
                return _products.FirstOrDefault(p => p.Title == title);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Add", ex);
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
                throw new RepositoryException("Add", ex);
            }
        }
    }
}
