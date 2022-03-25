using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesOrderApplication.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime CrearedDate { get; set; }

        public AddressDto Address { get; set; }

        public string BuyerId { get; set; }

        public List<OrderItemDto> orderItems { get; set; }
    }
}
