using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Service
{
    public interface IDeliveryCostService : IBaseService
    {
        public decimal GetDeliveryCost(Cart cart);
    }
}
