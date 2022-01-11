using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence
{
    public class StoreDbContextSeed
    {
        public static async Task SeedSampleDataAsync(StoreDbContext context)
        {
            // Seed, if necessary
            if (!context.Stores.Any(x => x.IsMyStore == true))
            {
                context.Stores.Add(new Domain.Entity.Store(
                    "My Store Name", 
                    "0900000000",
                    "Store Address",
                    isMyStore: true));

                await context.SaveChangesAsync();
            }
        }
    }
}