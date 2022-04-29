using System;

namespace FreeCourseProjectWebUI.Models.Orders
{
    public class OrderItemCreateInput
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public Decimal ProductPrice { get; set; }
    }
}
