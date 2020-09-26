using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Service;

namespace ShoppingCartServiceLib.Test
{
    [TestClass]
    public class CampaignServiceTest
    {
        [TestMethod]
        public void GetCampainsTotal()
        {
            var waitValue = 10m;

            Cart cart = new Cart();
            cart.Id = 1;

            cart.Carts.Add(new CartItem(new Product("p1", 50,1),3));
            cart.Carts.Add(new CartItem(new Product("p2", 70, 1), 4));

            var mock = new Mock<ICampaignRepository>();
            mock.Setup(c => c.FindByCategoryId(1)).Returns(new Campaign("unitTest", 10, 1));

            var service = new CampaignService(mock.Object);

            Assert.AreEqual(waitValue, service.GetCampainsTotal(cart));

        }
    }
}
