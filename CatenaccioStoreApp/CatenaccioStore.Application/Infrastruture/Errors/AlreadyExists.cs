using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Infrastruture.Errors
{
    public class AlreadyExists : Exception
    {
        public string Code = "Already exists";
        public AlreadyExists(string message) : base(message)
        {
        }
    }
}
