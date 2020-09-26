using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository;

namespace ShoppingCartRepositoryLib.Test
{
    [TestClass]
    public class CampaignRepositoryTest
    {
        private CampaignRepository _campaignRepository;
        #region
        [TestInitialize]
        public void TestInitialize()
        {
            _campaignRepository = new CampaignRepository();
            var c1 = new Campaign("Kampanya1", 10, 1);
            var c2 = new Campaign("Kampanya2", 5, 2);

            _campaignRepository.Add(c1);
            _campaignRepository.Add(c2);

        }

        #endregion

        [TestMethod]
        public void GetCount()
        {
            var waitValue = 2;

            Assert.AreEqual(waitValue, _campaignRepository.Count());            
        }

        [TestMethod]
        public void AddCampaign_SameTitle()
        {
            var waitValue = 2;
            _campaignRepository.Add(new Campaign("Kampanya1", 7, 1));

            Assert.AreEqual(waitValue, _campaignRepository.Count());
        }

        [TestMethod]
        public void DeleteById()
        {
            var waitValue = 1;

            _campaignRepository.DeleteById(1);

            Assert.AreEqual(waitValue, _campaignRepository.Count());
        }

        [TestMethod]
        public void ClearAll()
        {
            _campaignRepository.Clear();

            Assert.AreEqual(0, _campaignRepository.Count());
        }
    }
}
