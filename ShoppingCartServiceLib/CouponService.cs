
using Trendyol.ShoppingCart.Repository;

namespace Trendyol.ShoppingCart.Service
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepostory;

        public CouponService(ICouponRepository couponRepository) => _couponRepostory = couponRepository;


        public decimal GetCouponDiscount(decimal couponId, decimal cartAmount)
        {
            var coupon = _couponRepostory.FindById(couponId);

            if(cartAmount >= coupon.AmountConstraint)
                return coupon.Discount;

            return 0;
        }

    }
}
