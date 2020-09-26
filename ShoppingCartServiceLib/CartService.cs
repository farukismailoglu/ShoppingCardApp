using System;
using System.Collections.Generic;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service.Util;

namespace Trendyol.ShoppingCart.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository) => _cartRepository = cartRepository;

        public void Add(CartItem cartItem)
        {
            try
            {
                _cartRepository.Add(cartItem);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Add", ex);
            }
        }
        public void DeleteItem(decimal id)
        {
            try
            {
                if(_cartRepository.ExitsById(id))
                    _cartRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("DeleteItem", ex);
            }
        }

        public void Clear()
        {
            try
            {
                _cartRepository.ClearAll();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Clear", ex);
            }
        }

        public IEnumerable<CartItem> GetAll()
        {
            try
            {
                return _cartRepository.All();
            }
            catch (Exception ex)
            {
                throw new ServiceException("GetAll", ex);
            }
        }
         
    }
}
