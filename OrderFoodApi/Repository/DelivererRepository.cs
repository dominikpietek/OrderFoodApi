using Microsoft.EntityFrameworkCore;
using OrderFoodApi.Databases;
using OrderFoodApi.Interfaces;
using OrderFoodApi.Models;
using OrderFoodApi.Services;

namespace OrderFoodApi.Repository
{
    public class DelivererRepository : SaveChanges, IRepository<Deliverer>
    {
        private readonly OrderFoodDbContext _db;
        private readonly SaveChanges _save;

        public DelivererRepository(OrderFoodDbContext db)
        {
            _save = new SaveChanges();
            _db = db;
        }

        public async Task<bool> AddAsync(Deliverer obj)
        {
            await _db.Deliverers.AddAsync(obj);
            return await _save.SaveAsync(_db);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _db.Remove(await GetAsync(id));
            return await _save.SaveAsync(_db);
        }

        public async Task<List<Deliverer>> GetAllAsync()
        {
            return await _db.Deliverers.ToListAsync();
        }

        public async Task<Deliverer> GetAsync(int id)
        {
            return await _db.Deliverers.FirstAsync(d => d.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _db.Deliverers.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> UpdateAsync(Deliverer obj)
        {
            _db.Deliverers.Update(obj);
            return await _save.SaveAsync(_db);
        }
    }
}
