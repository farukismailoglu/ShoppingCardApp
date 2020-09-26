using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace ShoppingCartRepositoryLib.Test
{
    [TestClass]
    public class ParentCategoryRepositoryTest
    {
        private static ParentCategoryRepository _parentCategoryRepository;

        #region Test Initialize
        [TestInitialize]
        public void TestInitialize()
        {
            _parentCategoryRepository = new ParentCategoryRepository();
            _parentCategoryRepository.Add(new ParentCategory("Yiyecek"));
            _parentCategoryRepository.Add(new ParentCategory("Elektronik"));
        }
        #endregion

        [TestMethod]
        public void AddParentCategory()
        {
            var waitValue = 2;
       
            Assert.AreEqual(waitValue, _parentCategoryRepository.Count());
        }
        [TestMethod]
        public void AddParentCategory_SameCategory()
        {
            var waitValue = 2;

            _parentCategoryRepository.Add(new ParentCategory("Yiyecek"));

            Assert.AreEqual(waitValue, _parentCategoryRepository.Count());
        }

        [TestMethod]
        public void DeleteById()
        {
            var waitValue = 1;

            _parentCategoryRepository.DeleteById(1);

            Assert.AreEqual(waitValue, _parentCategoryRepository.Count());
        }

        [TestMethod]
        public void ClearAll()
        {
            _parentCategoryRepository.Clear();

            Assert.AreEqual(0, _parentCategoryRepository.Count());
        }
    }
}
