using System;
using System.Collections.Generic;
using System.Text;
using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Service
{
    public interface ICartService : IBaseService
    {
        public void Add(CartItem cartItem);

        public void DeleteItem(decimal id);

        public void Clear();

        public IEnumerable<CartItem> GetAll();
    }
}
