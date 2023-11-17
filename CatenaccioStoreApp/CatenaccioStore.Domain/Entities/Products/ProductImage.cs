namespace CatenaccioStore.Domain.Entities.Products
{
    public class ProductImage : BaseEntity
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
