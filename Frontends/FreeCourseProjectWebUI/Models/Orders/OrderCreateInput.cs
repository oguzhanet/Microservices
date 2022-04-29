using System.Collections.Generic;

namespace FreeCourseProjectWebUI.Models.Orders
{
    public class OrderCreateInput
    {
        public string BuyerId { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }

        public AddressCreateInput Address { get; set; }
    }
}
