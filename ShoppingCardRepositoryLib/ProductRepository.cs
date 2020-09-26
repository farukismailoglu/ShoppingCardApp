using System.Collections.Generic;
using System.Linq;
using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public class ProductRepository : IProductRepository
    {
        public static List<Product> _products = new List<Product>();
        public static int ms_index ;

        public ProductRepository() 
        { }
        public ProductRepository(Product product) => _products.Add(product);
        
        public void Add(Product product)
        {
            product.Id = ++ms_index;
            _products.Add(product);
        }

        public IEnumerable<Product> All() => _products;

        public int Count() => _products.Count();

        public void DeleteById(decimal id) => _products.Remove(_products.FirstOrDefault(p => p.Id == id));

        public bool ExitsById(decimal id) => FindById(id) != null;

        public Product FindById(decimal id) => _products.FirstOrDefault(p => p.Id == id);

        public Product FindByTitle(string title) => _products.FirstOrDefault(p => p.Title == title);

        public bool ExitsByTitle(string title) => FindByTitle(title) != null;

    }
}
