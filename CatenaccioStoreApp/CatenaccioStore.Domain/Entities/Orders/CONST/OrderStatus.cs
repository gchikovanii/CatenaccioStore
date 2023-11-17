using System.Runtime.Serialization;

namespace CatenaccioStore.Domain.Entities.Orders.CONST
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment Successful")]
        Successful,
        [EnumMember(Value = "Payment Failed")]
        Failed
    }
}
