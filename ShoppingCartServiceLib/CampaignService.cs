using System.Collections.Generic;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace Trendyol.ShoppingCart.Service
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository) => _campaignRepository = campaignRepository;

        private decimal SumProductDiscount(decimal discount, int quantity)
        {
            decimal productDiscount = discount;

            for (int i = 1; i < quantity; i++)
            {
                productDiscount += (discount % 2);
            }

            return productDiscount;
        }

        private decimal SumCampaignDiscount(decimal categoryId, int quantity)
        {
            var campaign = _campaignRepository.FindByCategoryId(categoryId);

            return SumProductDiscount(campaign.Discount, quantity);
        }

        public decimal GetCampainsTotal(Cart cart)
        {
            decimal totalDiscount = 0;

            foreach (var cartItem in cart.Carts)
                totalDiscount = SumCampaignDiscount(cartItem.Product.CategoryId, cartItem.Quantity);

            return totalDiscount;
        }

    }
}
