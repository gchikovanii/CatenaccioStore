using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Infrastructure.Units;

namespace CatenaccioStore.Application.Services.Products.Implementation
{
    public class OfferService : IOfferService
    {
        private readonly IOfferService _offerService;
        private readonly IUnitOfWork _unitOfWork;
        public OfferService(IOfferService offerService, IUnitOfWork unitOfWork)
        {
            _offerService = offerService;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<OfferDto>> GetAllOffers(CancellationToken token)
        {
            return await _offerService.GetAllOffers(token);
        }
        public async Task<bool> CreateAsync(CancellationToken cancellationToken, OfferDto offer)
        {
            await _offerService.CreateAsync(cancellationToken, offer);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, string productName)
        {
            await _offerService.DeleteAsync(cancellationToken, productName);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
