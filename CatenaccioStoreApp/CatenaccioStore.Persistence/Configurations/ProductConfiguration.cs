using CatenaccioStore.Domain.Entities.Orders;
using CatenaccioStore.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CatenaccioStore.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(i => i.Category).WithMany(i => i.Products).HasForeignKey(i => i.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(i => i.Images).WithOne(i => i.Product).HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(i => i.Price).HasColumnType("decimal(18, 2)");
        }
    }
}
