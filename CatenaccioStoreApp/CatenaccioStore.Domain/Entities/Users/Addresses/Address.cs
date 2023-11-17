namespace CatenaccioStore.Domain.Entities.Users.Addresses
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
