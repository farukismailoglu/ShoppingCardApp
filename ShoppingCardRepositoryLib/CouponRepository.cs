using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Repository.Util;

namespace Trendyol.ShoppingCart.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly List<Coupon> _coupons  = new List<Coupon>();
        private static int ms_index;

        public void Add(Coupon coupon)
        {
            try
            {
                if (!ExitsById(coupon.Id))
                {
                    coupon.Id = ++ms_index;
                    _coupons.Add(coupon);
                }
                else
                {
                    var updateCoupon = FindById(coupon.Id);
                    updateCoupon.Discount = coupon.Id;
                    updateCoupon.AmountConstraint = coupon.AmountConstraint;

                }
                
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Add", ex);
            }
        }

        public void DeleteById(decimal id)
        {
            try
            {
                _coupons.Remove(FindById(id));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DeleteByID", ex);
            }
        }

        public bool ExitsById(decimal id)
        {
            try
            {
                return FindById(id) != null; ;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ExitById", ex);
            }
        }

        public bool ExitsByTitle(string title)
        {
            try
            {
                return FindByTitle(title) != null; ;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ExitBytitle", ex);
            }
        }

        public Coupon FindById(decimal id)
        {
            try
            {
                return _coupons.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindById", ex);
            }
        }

        public Coupon FindByTitle(string title)
        {
            try
            {
                return _coupons.FirstOrDefault(c => c.Title == title);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindByTitle", ex);
            }
        }

        public int Count()
        {
            try
            {
                return _coupons.Count;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Count", ex);
            }

        }
    }
}
