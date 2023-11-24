using CatenaccioStore.Infrastructure.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Infrastructure.Errors
{
    public class FileNotFoundError : Exception
    {
        public string Code = ErrorMessages.FileNotFound;
        public FileNotFoundError(string message) : base(message)
        {
        }
    }
}