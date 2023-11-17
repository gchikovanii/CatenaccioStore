using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Infrastructure.Errors
{
    public class ImageNotUploadedException : Exception
    {
        public string Code = "Image not uploaded";
        public ImageNotUploadedException(string message) : base(message)
        {
        }
    }
}