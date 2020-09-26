namespace Trendyol.ShoppingCart.Service
{
    public interface ICouponService : IBaseService
    {
        public decimal GetCouponDiscount(decimal couponId, decimal cartAmount);
    }
}
