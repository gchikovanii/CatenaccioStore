namespace CatenaccioStore.Domain.Entities.Orders
{
    public class ProductItemOrdered : BaseEntity
    {
        //Snaposhot of what user ordered. Escape if product will change in futre, what was the real order.
        public ProductItemOrdered()
        {
        }
        public ProductItemOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}
