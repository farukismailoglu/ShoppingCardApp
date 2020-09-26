using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository.Util;

namespace Trendyol.ShoppingCart.Repository
{
    public class CartRepository : ICartRepository
    {
        private static Cart _cart = new Cart();
        private static int ms_index;
        private static int userId = 1;
        public CartRepository()
        { }
        public CartRepository(CartItem cartItem)
        {
            _cart.Id = userId;
            _cart.Carts.Add(cartItem);
        }
        public void Add(CartItem cartItem)
        {
            try
            {
                if (!ExitsByTitle(cartItem.Product.Title))
                {
                    cartItem.Id = ++ms_index;
                    _cart.Carts.Add(cartItem);
                }
                else
                {
                    var a = _cart.Carts.FirstOrDefault(c => c.Product.Title != cartItem.Product.Title);
                    a.Quantity += cartItem.Quantity;
                }
            }
            catch (Exception ex )
            {

                throw new RepositoryException("Add", ex);
            }
            
        }

        public void DeleteById(decimal id)
        {
            try
            {
                var cartItem = _cart.Carts.FirstOrDefault(c => c.Id == id);

                _cart.Carts.Remove(cartItem);
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteById", ex);
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
                throw new RepositoryException("ExitsById", ex);
            }
            
        }

        public CartItem FindById(decimal id)
        {
            try
            {
                return _cart.Carts.FirstOrDefault(c => c.Product.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindById", ex);
            }

        }

        public CartItem FindByTitle(string title)
        {
            try
            {
                return _cart.Carts.FirstOrDefault(c => c.Product.Title == title);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindByTitle", ex);
            }
            
        }

        public int CartItemCount(decimal id)
        {
            try
            {
                return _cart.Carts.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("CartItemCount", ex);
            }

        }

        public int TotalProductCount(decimal id)
        {
            try
            {
                int totalProductCount = 0;

                foreach (var cartItem in _cart.Carts)
                    totalProductCount += cartItem.Quantity;

                return totalProductCount;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TotalProductCount", ex);
            }
            
        }
    }
}
