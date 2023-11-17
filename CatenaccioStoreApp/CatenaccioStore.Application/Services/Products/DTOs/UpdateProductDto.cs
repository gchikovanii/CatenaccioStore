using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Products.DTOs
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public decimal Prie { get; set; } = 0;
        public int CategoryId { get; set; }
    }
}
