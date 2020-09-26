using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public interface ICouponRepository : IBaseRepository<Coupon, decimal>
    {
        public int Count();
    }
}
