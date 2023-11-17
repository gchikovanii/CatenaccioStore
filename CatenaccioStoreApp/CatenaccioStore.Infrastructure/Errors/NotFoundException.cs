namespace CatenaccioStore.Infrastructure.Errors
{
    public class NotFoundException : Exception
    {
        public string Code = "Not Found";
        public NotFoundException(string message) : base(message)
        {
        }
    }
}