using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Errors;
using CatenaccioStore.Infrastructure.Localizations;
using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using Microsoft.EntityFrameworkCore;

namespace CatenaccioStore.Infrastructure.Repositories.Implementation.Products
{
    public class OffeRepository : IOffeRepository
    {
        private readonly IRepository<Offer> _repository;
        private readonly IRepository<Product> _productRepository;

        public OffeRepository(IRepository<Offer> repository, IRepository<Product> productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }
        public async Task<List<Offer>> GetAll(CancellationToken token)
        {
            return await _repository.GetQuery().ToListAsync(token);
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Offer offer)
        {
            var offerExists = await _repository.GetQuery(i => i.Id == offer.Id).SingleOrDefaultAsync(cancellationToken);
            if (offerExists != null)
                throw new AlreadyExists(ErrorMessages.AlreadyExists);
            await _repository.AddAsync(offer, cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, string productName)
        {
            var result = await _productRepository.GetQuery(i => i.ProductName == productName).SingleOrDefaultAsync(cancellationToken);
            if(result == null) 
                throw new NotFoundException(ErrorMessages.NotFound);
            var offerToDelete = await _repository.GetQuery(i => i.ProductId == result.Id).SingleOrDefaultAsync(cancellationToken);
            if(offerToDelete == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            await _repository.RemoveAsync(cancellationToken, offerToDelete);
        }
    }
}
