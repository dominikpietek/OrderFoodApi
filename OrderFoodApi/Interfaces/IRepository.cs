namespace OrderFoodApi.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetAsync(int id);
        public Task<bool> IsExistsAsync(int id);
        public Task<bool> UpdateAsync(T obj);
        public Task<bool> DeleteAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task<bool> AddAsync(T obj);
        public Task<bool> SaveAsync();
    }
}
