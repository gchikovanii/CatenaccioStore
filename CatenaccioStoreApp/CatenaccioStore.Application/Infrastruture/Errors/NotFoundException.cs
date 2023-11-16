using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Infrastruture.Errors
{
    public class NotFoundException : Exception
    {
        public string Code = "Not Found";
        public NotFoundException(string message): base(message)
        {
        }
    }
}
