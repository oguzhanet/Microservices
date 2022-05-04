using FreeCourseProjectWebUI.Models.Orders;

namespace FreeCourseProjectWebUI.Models.FakePayments
{
    public class FakePaymentInfoInput
    {
        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string Expiration { get; set; }

        public string Cvv { get; set; }

        public decimal Price { get; set; }

        public OrderCreateInput Order { get; set; }
    }
}
