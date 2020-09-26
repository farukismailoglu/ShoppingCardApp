using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service;

namespace ShoppingCartServiceLib.Test
{
    [TestClass]
    public class CouponServiceTest
    {
        [TestMethod]
        public void GetCouponDiscount_Insufficient_AmountCart()
        {
            var waitValue = 0m;
            var mock = new Mock<ICouponRepository>();
            mock.Setup(c => c.FindById(1)).Returns(new Coupon("c1", 5, 5));

            var service = new CouponService(mock.Object);

            Assert.AreNotEqual(waitValue, service.GetCouponDiscount(1, 10));
            
        }

        [TestMethod]
        public void GetCouponDiscount_Enough_AmountCart()
        {
            var waitValue = 0m;
            var mock = new Mock<ICouponRepository>();
            mock.Setup(c => c.FindById(1)).Returns(new Coupon("c1", 25, 5));

            var service = new CouponService(mock.Object);

            Assert.AreEqual(waitValue, service.GetCouponDiscount(1, 10));

        }

    }
}
