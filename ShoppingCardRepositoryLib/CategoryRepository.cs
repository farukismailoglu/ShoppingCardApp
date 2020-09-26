using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Trendyol.ShoppingCart.Model;

namespace Trendyol.ShoppingCart.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories = new List<Category>();
        private static int ms_index;

        public CategoryRepository()
        { }
        public CategoryRepository(Category category) => _categories.Add(category);

        public void Add(Category category) {
            category.Id = ++ms_index;
            _categories.Add(category);
        }
        public IEnumerable<Category> All() => _categories;
        public int Count() => _categories.Count();
        public void DeleteById(decimal id)
        {
            var c = FindById(id);

            if (c == null)
                return;

            _categories.Remove(c);
        }

        public bool ExitsById(decimal id) => FindById(id) != null;

        public bool ExitsByTitle(string title) => FindByTitle(title) != null;

        public Category FindById(decimal id) => _categories.FirstOrDefault(c => c.Id.Equals(id));

        public Category FindByTitle(string title) => _categories.FirstOrDefault(c => c.Title.Equals(title));

    }
}
