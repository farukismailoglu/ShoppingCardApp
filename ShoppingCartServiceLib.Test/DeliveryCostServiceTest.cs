using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trendyol.ShoppingCart.Model;
using System.Linq.Expressions;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service;
using System.Threading;

namespace ShoppingCartServiceLib.Test
{
    [TestClass]
    public class DeliveryCostServiceTest
    {
        [TestMethod]
        public void DeliveryCost()
        {
            var waitValue = 5.4m;
            var mock = new Mock<ICartRepository>();
            mock.Setup(c => c.CartItemCount(1)).Returns(3);
            mock.Setup(c => c.TotalProductCount(1)).Returns(2);

            var service = new DeliveryCostService(mock.Object);

            Cart cart = new Cart();
            cart.Id = 1;

            Assert.AreEqual(waitValue, service.GetDeliveryCost(cart));
        }
    }
}
