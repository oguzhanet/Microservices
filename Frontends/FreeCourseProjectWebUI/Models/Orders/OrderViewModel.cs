using System;
using System.Collections.Generic;

namespace FreeCourseProjectWebUI.Models.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime CrearedDate { get; set; }

        public string BuyerId { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
