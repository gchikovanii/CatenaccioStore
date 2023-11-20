using CatenaccioStore.Infrastructure.Localizations;

namespace CatenaccioStore.Infrastructure.Errors
{
    public class NotFoundException : Exception
    {
        public string Code = ErrorMessages.NotFound;
        public NotFoundException(string message) : base(message)
        {
        }
    }
}