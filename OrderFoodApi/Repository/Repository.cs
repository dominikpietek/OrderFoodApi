using Microsoft.EntityFrameworkCore;
using OrderFoodApi.Databases;
using OrderFoodApi.Interfaces;
using OrderFoodApi.Models;
using OrderFoodApi.Services;

namespace OrderFoodApi.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase
    {
        private readonly OrderFoodDbContext _db;
        private readonly DbSet<T> _base;

        public Repository(OrderFoodDbContext db)
        {
            _db = db;
            _base = _db.Set<T>();
        }

        public async Task<bool> AddAsync(T obj)
        {
            await _base.AddAsync(obj);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _base.Remove(await GetAsync(id));
            return await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _base.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _base.FirstAsync(d => d.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _base.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            _base.Update(obj);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var save = await _db.SaveChangesAsync();
            return save > 0 ? true : false;
        }
    }
}
