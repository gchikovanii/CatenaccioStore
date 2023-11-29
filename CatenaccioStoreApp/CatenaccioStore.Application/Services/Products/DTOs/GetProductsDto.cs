using CatenaccioStore.Domain.Entities.Products;

namespace CatenaccioStore.Application.Services.Products.DTOs
{
    public class GetProductsDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
