namespace CatenaccioStore.Domain.Entities.Orders
{
    public class ShippingAddress
    {
        //Without Id So it Will be owned by Orders, Order Table will include shipping address
        public ShippingAddress()
        {
        }
        public ShippingAddress(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
