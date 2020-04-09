using System.Threading.Tasks;

namespace actio.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}