using CatenaccioStore.Domain.Entities.Products;

namespace CatenaccioStore.Infrastructure.Repositories.Abstraction.Products
{
    public interface IOffeRepository
    {
        Task<List<Offer>> GetAll(CancellationToken token);
        Task CreateAsync(CancellationToken cancellationToken, Offer offer);
        Task DeleteAsync(CancellationToken cancellationToken, string productName);
    }
}
