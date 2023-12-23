using System.ComponentModel.DataAnnotations;

namespace CatenaccioStore.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Title")]
        public string ShortTitle { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
