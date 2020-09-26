using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace ShoppingCartRepositoryLib.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private static ProductRepository _productRepository;
        private static CategoryRepository _categoryRepository;

        #region Class Level Initialize/Cleanup
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _categoryRepository = new CategoryRepository();
            _categoryRepository.Add(new Category("Meyve"));
        }

        #endregion
        #region Test Level Initialize/Cleanup
        [TestInitialize]
        public void InitializeTest()
        {
            _productRepository = new ProductRepository();
            _productRepository.Add(new Product("Elma", 50, 1));
            _productRepository.Add(new Product("Armut", 30, 1));

        }
        #endregion
        
        [TestMethod]
        public void GetCountProducts()
        {
            var waitValue = 2;
            var totalProductCount = _productRepository.Count();

            Assert.AreEqual(waitValue, totalProductCount);
        }


        [TestMethod]
        public void AddProducts()
        {
            int waitValue = 2; 
            
            var totalProductCount = _productRepository.Count();

            Assert.AreEqual(waitValue, totalProductCount);
        }

        [TestMethod]
        public void DeleteByIdProduct()
        {
            int waitValue = 1;

            _productRepository.DeleteById(1);

            var totalProductCount = _productRepository.Count();

            Assert.AreEqual(waitValue, totalProductCount);
        }

        [TestMethod]
        public void FindByIdProduct()
        {
            var waitId = 2;
            var waitTitle = "Armut";

            var findProduct = _productRepository.FindById(2);

            Assert.AreEqual(waitId, findProduct.Id);
            Assert.AreEqual(waitTitle, findProduct.Title);

        }

        [TestMethod]
        public void FindByTitleProduct()
        {
            var waitId = 2;
            var waitTitle = "Armut";

            var findProduct = _productRepository.FindByTitle("Armut");

            Assert.AreEqual(waitId, findProduct.Id);
            Assert.AreEqual(waitTitle, findProduct.Title);

        }
    }
}
