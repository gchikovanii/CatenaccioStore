using CatenaccioStore.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Products.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public string Brand { get; set; } 
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
