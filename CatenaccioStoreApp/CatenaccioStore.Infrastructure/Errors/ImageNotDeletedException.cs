using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Infrastructure.Errors
{
    public class ImageNotDeletedException : Exception
    {
        public string Code = "Not Deleted";
        public ImageNotDeletedException(string message) : base(message)
        {
        }
    }
}