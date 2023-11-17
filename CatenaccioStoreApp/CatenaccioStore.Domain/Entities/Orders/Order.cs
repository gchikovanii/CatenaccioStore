using CatenaccioStore.Domain.Entities.Users.Addresses;
using CatenaccioStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatenaccioStore.Domain.Entities.Orders.CONST;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatenaccioStore.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }
        public Order(string buyerEmail, ShippingAddress shippingAddress, 
            DeliveryMethod deliveryMethod, IReadOnlyList<OrderItem> orderItems, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public int BuyerId { get; set; }
        public AppUser Buyer { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public ShippingAddress ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total => GetTotal();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

    }
}
