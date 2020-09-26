using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public interface ICartRepository : IBaseRepository<CartItem, decimal>
    {
        public int CartItemCount(decimal id);


        public int TotalProductCount(decimal id);
    }
}
