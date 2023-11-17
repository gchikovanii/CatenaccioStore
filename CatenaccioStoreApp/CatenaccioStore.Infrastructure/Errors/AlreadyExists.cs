namespace CatenaccioStore.Infrastructure.Errors
{
    public class AlreadyExists : Exception
    {
        public string Code = "Already exists";
        public AlreadyExists(string message) : base(message)
        {
        }
    }
}