using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;
using Trendyol.ShoppingCart.Repository.Util;


namespace ShoppingCartRepositoryLib.Test
{   
    [TestClass]
    public class CategoryRepositoryTest
    {
        private  static CategoryRepository _categoryRepository;
        #region Test Level Initialize/Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            _categoryRepository = new CategoryRepository();

            _categoryRepository.Add(new Category("Meyve"));
            _categoryRepository.Add(new Category("Sebze"));
        }

        #endregion

        [TestMethod]
        public void GetCountCategories()
        {
            var waitValue = 2;
            var totalCategoriesCount = _categoryRepository.Count();

            Assert.AreEqual(waitValue, totalCategoriesCount);
        }

        [TestMethod]
        public void AddCategories()
        {
            int waitValue = 2;
            var totalProductCount = _categoryRepository.Count();

            Assert.AreEqual(waitValue, totalProductCount);
        }

        [TestMethod]
        public void FindById()
        {            
            var waitId = 2;
            var waitTitle = "Elektronik";

            var findCategory = _categoryRepository.FindById(2);

            Assert.AreEqual(waitId, findCategory.Id);
            Assert.AreEqual(waitTitle, findCategory.Title);
        }

        [TestMethod]
        public void ExitsById()
        {
            Assert.AreEqual(true, _categoryRepository.ExitsById(1));
            Assert.AreEqual(false, _categoryRepository.ExitsById(1999));
        }

        [TestMethod]
        public void FindByTitle()
        {
            var waitId = 1;
            var waitTitle = "Meyve";

            Assert.AreEqual(waitId, _categoryRepository.FindByTitle("Meyve").Id);
            Assert.AreEqual(waitTitle, _categoryRepository.FindByTitle("Meyve").Title);

            Assert.AreEqual(null, _categoryRepository.FindByTitle("xxxxxxxxx12312ssfdsfsdfdsfs"));
        }

        [TestMethod]
        public void ExitsByTitle()
        {
            Assert.AreEqual(true, _categoryRepository.ExitsByTitle("Meyve"));
            Assert.AreEqual(false, _categoryRepository.ExitsByTitle("xxxxxxxxx12312ssfdsfsdfdsfs"));
        }

        [TestMethod]
        public void DeleteById()
        {
            int waitValue = 1;
            
            _categoryRepository.DeleteById(1);

            Assert.AreEqual(waitValue, _categoryRepository.Count());

        }
        
    }
}
