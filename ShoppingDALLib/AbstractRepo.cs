
namespace ShoppingDALLib
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = [];
        public virtual Task<T> Add(T item)
        {
            items.Add(item);
            return Task.FromResult(item);
        }

        public Task<List<T>> GetAll()
        {
            items.Sort();
            var result = items.ToList<T>();
            return Task.FromResult(result);
        }

        public abstract Task<T> Delete(K key);


        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);

    }
}
