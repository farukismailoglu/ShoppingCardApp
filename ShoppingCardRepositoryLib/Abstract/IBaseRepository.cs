namespace Trendyol.ShoppingCart.Repository
{
    public interface IBaseRepository<T, ID>
    {
        public void Add(T t);
        public void DeleteById(ID id);
        
        public T FindById(ID id);
        public bool ExitsById(ID id);
        public T FindByTitle(string title);
        public bool ExitsByTitle(string title);

    }
}
