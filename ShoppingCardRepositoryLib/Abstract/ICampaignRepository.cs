using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public interface ICampaignRepository : IBaseRepository<Campaign, decimal>
    {
        public int Count();

        public void Clear();

        public Campaign FindByCategoryId(decimal categoryId);
    }
}
