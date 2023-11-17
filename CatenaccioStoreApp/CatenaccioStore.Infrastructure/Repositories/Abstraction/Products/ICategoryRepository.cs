using CatenaccioStore.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Infrastructure.Repositories.Abstraction.Products
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task CreateAsync(CancellationToken cancellationToken, Category product);
        Task UpdateAsync(CancellationToken cancellationToken, string categoryName, string newName);
        Task DeleteAsync(CancellationToken cancellationToken, string categoryName);
    }
}
