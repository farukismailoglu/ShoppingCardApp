using System;
using System.Collections.Generic;
using System.Text;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace Trendyol.ShoppingCart.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly List<Coupon> _coupons  = new List<Coupon>();
        public void Add(Coupon t)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(decimal id)
        {
            throw new NotImplementedException();
        }

        public bool ExitsById(decimal id)
        {
            throw new NotImplementedException();
        }

        public bool ExitsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Coupon FindById(decimal id)
        {
            throw new NotImplementedException();
        }

        public Coupon FindByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public int Count() => _coupons.Count;

    }
}
