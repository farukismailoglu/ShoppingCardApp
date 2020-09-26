using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace Trendyol.ShoppingCart.Service
{
    public class DeliveryCostService : IDeliveryCostService
    {
        private readonly ICartRepository _cartRepository;

        private const decimal deliveryCost = 1.2m;
        private const decimal productDeliveryCost = 0.9M;

        public DeliveryCostService(ICartRepository cartRepository) => _cartRepository = cartRepository;

        private decimal DeliveryCost(decimal id) => deliveryCost * _cartRepository.CartItemCount(id);

        private decimal ProductDeliveryCost(decimal id) => productDeliveryCost * _cartRepository.TotalProductCount(id);

        public decimal GetDeliveryCost(Cart cart) => DeliveryCost(cart.Id) + ProductDeliveryCost(cart.Id);


    }
}
