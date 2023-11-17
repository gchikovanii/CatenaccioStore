using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Products.DTOs
{
    public class CreateProductImagesDto
    {
        public string ProductName { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
