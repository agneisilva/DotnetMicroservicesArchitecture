using System.Threading.Tasks;

namespace actio.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}