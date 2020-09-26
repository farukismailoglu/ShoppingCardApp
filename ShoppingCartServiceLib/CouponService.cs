using System;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service.Util;

namespace Trendyol.ShoppingCart.Service
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepostory;

        public CouponService(ICouponRepository couponRepository) => _couponRepostory = couponRepository;


        public decimal GetCouponDiscount(decimal couponId, decimal cartAmount)
        {
            try
            {
                var coupon = _couponRepostory.FindById(couponId);

                if (cartAmount >= coupon.AmountConstraint)
                    return coupon.Discount;

                return 0;
            }
            catch (Exception ex)
            {
                throw new ServiceException("GetCouponDiscount", ex);
            }
            
        }

    }
}
