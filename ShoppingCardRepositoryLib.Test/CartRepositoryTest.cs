using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace ShoppingCartRepositoryLib.Test
{
    [TestClass]
    public class CartRepositoryTest
    {
        private static ProductRepository _productRepository;
        private static CategoryRepository _categoryRepository;
        private static CartRepository _cartRepository;
        private static List<Product> _products =new List<Product>();
        private static int userId = 1;

        #region Class Level Initialize/Cleanup
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _categoryRepository = new CategoryRepository();
            _categoryRepository.Add(new Category("Meyve"));

            Product p1 = new Product("Elma", 50, userId);
            Product p2 = new Product("Armut", 30, userId);
            _productRepository = new ProductRepository();
            _productRepository.Add(p1);
            _productRepository.Add(p2);

            _products.Add(p1);
            _products.Add(p2);
        }

        #endregion
        #region Test Level Initialize/Cleanup
        [TestInitialize]
        public void InitializeTest()
        {
            _cartRepository = new CartRepository();

            _cartRepository.Add(new CartItem(_products[0], 1));
            _cartRepository.Add(new CartItem(_products[1], 2));

        }
        #endregion

        [TestMethod]
        public void GetCountCartItem()
        {
            var waitValue = 2;

            Assert.AreEqual(waitValue, _cartRepository.CartItemCount(userId));
        }

        [TestMethod]
        public void AddProductstoCart_DifferentProduct()
        {
            var waitValue = 3;
            var p = new Product("Muz", 15, 1);
            _cartRepository.Add(new CartItem(p,3));

            Assert.AreEqual(waitValue, _cartRepository.CartItemCount(userId));

        }

        [TestMethod]
        public void AddProductstoCart_SameProduct()
        {
            var waitValue = 2;
            var p = new Product("Armut", 15, 1);
            _cartRepository.Add(new CartItem(p, 3));

            Assert.AreEqual(waitValue, _cartRepository.CartItemCount(userId));

        }

        [TestMethod]
        public void TotalProductCount()
        {
            var waitValue = 3;

            Assert.AreEqual(waitValue, _cartRepository.TotalProductCount(userId));
        }
    }
}
