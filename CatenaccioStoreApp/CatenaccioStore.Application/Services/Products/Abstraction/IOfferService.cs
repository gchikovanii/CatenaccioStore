using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;

namespace CatenaccioStore.Application.Services.Products.Abstraction
{
    public interface IOfferService
    {
        Task<List<OfferDto>> GetAllOffers(CancellationToken token);
        Task<bool> CreateAsync(CancellationToken cancellationToken, OfferDto offer);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, string productName);
    }
}
