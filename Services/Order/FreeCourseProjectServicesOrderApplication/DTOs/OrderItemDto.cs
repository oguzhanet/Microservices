using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesOrderApplication.DTOs
{
    public class OrderItemDto
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public Decimal ProductPrice { get; set; }
    }
}
