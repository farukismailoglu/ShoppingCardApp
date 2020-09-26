using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.ShoppingCart.Model;

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

        public void DeleteById(decimal id)
        {
            throw new NotImplementedException();
        }

        public bool ExitsById(decimal id) => FindById(id) != null;

        public bool ExitsByTitle(string title) => FindByTitle(title) != null;

        public CartItem FindById(decimal id) => _cart.Carts.FirstOrDefault(c => c.Product.Id.Equals(id));

        public CartItem FindByTitle(string title) => _cart.Carts.FirstOrDefault(c => c.Product.Title == title);

        public int CartItemCount(decimal id) => _cart.Carts.Count();

        public int TotalProductCount(decimal id)
        {
            int totalProductCount = 0;

            foreach(var cartItem in _cart.Carts)
                totalProductCount += cartItem.Quantity;
            
            return totalProductCount;
        }
    }
}
