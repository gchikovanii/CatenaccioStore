using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CatenaccioStore.Domain.Entities.Products;

namespace CatenaccioStore.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(i => i.NewPrice).HasColumnType("decimal(18,2)");
        }
    }
}
