using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Service
{
    public interface ICampaignService : IBaseService
    {
        public decimal GetCampainsTotal(Cart cart);
    }
}
