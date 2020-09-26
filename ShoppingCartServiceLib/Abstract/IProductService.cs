using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Service
{
    public interface IProductService : IBaseService
    {
        public void Add(Product product);

        public void Delete(decimal id);

        public Product SearchByTitle(string title);
    }
}
