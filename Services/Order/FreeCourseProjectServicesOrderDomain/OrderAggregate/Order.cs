using FreeCourseProjectServicesOrderDomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesOrderDomain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CrearedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OderItems => _orderItems;

        public Order() { }

        public Order(Address address, string buyerId)
        {
            CrearedDate = DateTime.Now;
            Address = address;
            BuyerId = buyerId;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(string productId, string productName, decimal productPrice, string pictureUrl)
        {
            var existProduct=_orderItems.Any(x=>x.ProductId==productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, productPrice);

                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.ProductPrice);
    }
}
