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