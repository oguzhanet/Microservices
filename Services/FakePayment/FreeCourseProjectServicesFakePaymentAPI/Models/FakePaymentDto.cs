namespace FreeCourseProjectServicesFakePaymentAPI.Models
{
    public class FakePaymentDto
    {
        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string Expiration { get; set; }

        public string Cvv { get; set; }

        public decimal Price { get; set; }

        public OrderDto Order { get; set; }
    }
}
