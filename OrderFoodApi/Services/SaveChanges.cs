using OrderFoodApi.Databases;

namespace OrderFoodApi.Services
{
    public class SaveChanges
    {
        public async Task<bool> SaveAsync(OrderFoodDbContext db)
        {
            var save = await db.SaveChangesAsync();
            return save > 0 ? true : false;
        }
    }
}
