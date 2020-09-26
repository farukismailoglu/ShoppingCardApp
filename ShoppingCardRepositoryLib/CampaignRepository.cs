using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        private static List<Campaign> _campaigns = new List<Campaign>();
        private static int ms_index;

        public CampaignRepository()
        { }

        public CampaignRepository(Campaign campaign)
        {
            _campaigns.Add(campaign);
        }

        public void Add(Campaign campaign)
        {
            if (!ExitsByTitle(campaign.Title))
            {
                campaign.Id += ++ms_index;
                _campaigns.Add(campaign);
            }
        }

        public void DeleteById(decimal id)
        {
            var c = FindById(id);

            if (c == null)
                return;

            _campaigns.Remove(c);
        }

        public bool ExitsById(decimal id) => FindById(id) != null;

        public Campaign FindById(decimal id) => _campaigns.FirstOrDefault(c => c.Id == id);

        public Campaign FindByTitle(string title) => _campaigns.FirstOrDefault(c => c.Title == title);

        public bool ExitsByTitle(string title) => FindByTitle(title) != null;

        public int Count() => _campaigns.Count();

        public void Clear() => _campaigns.Clear();

        public Campaign FindByCategoryId(decimal categoryId) => _campaigns.FirstOrDefault(c => c.CategoryId == categoryId);

    }
}
