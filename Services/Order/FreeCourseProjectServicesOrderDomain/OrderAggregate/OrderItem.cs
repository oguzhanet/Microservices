using FreeCourseProjectServicesOrderDomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesOrderDomain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string PictureUrl { get; private set; }

        public Decimal ProductPrice { get; private set; }

        public OrderItem() { }

        public OrderItem(string productId, string productName, string pictureUrl, decimal productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            ProductPrice = productPrice;
        }

        public void UpdateOderItem(string productName, string pictureUrl, decimal productPrice)
        {
            ProductName = productName;
            PictureUrl = pictureUrl;
            ProductPrice = productPrice;
        }
    }
}
