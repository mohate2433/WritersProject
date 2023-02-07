namespace EntityFramework.GenericEfCore.Contract
{
    public interface IRepository<Tkey, T> where T : class
    {
        List<T> GetAll();
        T Get(Tkey id);
        void Delete(Tkey id);
        void Create(T entity);
        void Update(T entity);
    }
}
