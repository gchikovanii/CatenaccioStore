using CatenaccioStore.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Products.DTOs
{
    public class CreationProductDto
    {
        public string ProductName { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
