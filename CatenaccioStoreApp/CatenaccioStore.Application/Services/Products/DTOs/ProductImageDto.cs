using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Products.DTOs
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}
