namespace ShoppingDALLib
{
    public interface IRepository<K, T>
    {
        Task<T> Add(T item);
        Task<T> GetByKey(K key);
        Task<List<T>> GetAll();
        Task<T> Update(T item);
        Task<T> Delete(K key);

    }
}
