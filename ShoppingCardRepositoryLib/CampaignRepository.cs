using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Trendyol.ShoppingCart.Model;
using Trendyol.ShoppingCart.Repository.Util;

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
            try
            {
                if (!ExitsByTitle(campaign.Title))
                {
                    campaign.Id += ++ms_index;
                    _campaigns.Add(campaign);
                }
                else
                {
                    var updateCategory = FindByCategoryId(campaign.CategoryId);
                    updateCategory.CategoryId = campaign.CategoryId;
                    updateCategory.Discount = campaign.Discount;
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
                var c = FindById(id);

                if (c == null)
                    return;

                _campaigns.Remove(c);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DeleteById", ex);
            }
            
        }

        public bool ExitsById(decimal id)
        {
            try
            {
                return FindById(id) != null;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ExitsById" ,ex);
            }
            
        }

        public Campaign FindById(decimal id)
        {
            try
            {
                return _campaigns.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("FindById", ex);
            }
            
        }

        public Campaign FindByTitle(string title)
        {
            try
            {
                return _campaigns.FirstOrDefault(c => c.Title == title);

            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindByTitle", ex);
            }
        }

        public bool ExitsByTitle(string title)
        {
            try
            {
                return FindByTitle(title) != null;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ExitsByTitle", ex);
            }
            
        }

        public int Count()
        {
            try
            {
                return _campaigns.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Count", ex);
            }
            
        }

        public void Clear()
        {
            try
            {
                _campaigns.Clear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Clear", ex);
            }

        }

        public Campaign FindByCategoryId(decimal categoryId)
        {
            try
            {
                return _campaigns.FirstOrDefault(c => c.CategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("FindByCategoryId", ex);
            }
            
        }
    }
}
