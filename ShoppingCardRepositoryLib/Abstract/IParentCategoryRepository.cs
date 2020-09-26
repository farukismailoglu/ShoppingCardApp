using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public interface IParentCategoryRepository :IBaseRepository<ParentCategory, decimal>
    {
        public int Count();

        public void Clear();
    }
}
