using System;

namespace FreeCourseProjectWebUI.Models.Orders
{
    public class OrderItemViewModel
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public Decimal ProductPrice { get; set; }
    }
}
