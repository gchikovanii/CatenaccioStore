using CatenaccioStore.Domain.Entities.Orders;
using CatenaccioStore.Domain.Entities.Orders.CONST;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatenaccioStore.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(i => i.ShippingAddress, o =>
            {
                o.WithOwner();
            });
            builder.Property(i => i.Status).HasConversion(o => o.ToString(), o => (OrderStatus)Enum.Parse(typeof(OrderStatus),o));
            builder.HasMany(i => i.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Property(i => i.Subtotal).HasColumnType("decimal(18, 2)");

        }
    }
}
