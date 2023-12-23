namespace CatenaccioStore.Domain.Entities.Products
{
    public class Offer : BaseEntity
    {
        public decimal NewPrice { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
