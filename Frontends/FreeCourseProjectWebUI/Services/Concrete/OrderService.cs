using FreeCourseProjectWebUI.Models.FakePayments;
using FreeCourseProjectWebUI.Models.Orders;
using FreeCourseProjectWebUI.Services.Abstract;
using FreeCourseShared.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private ISharedIdentityService _sharedIdentityService;
        private readonly HttpClient _httpClient;

        public OrderService(IPaymentService paymentService, IBasketService basketService, ISharedIdentityService sharedIdentityService, HttpClient httpClient)
        {
            _paymentService = paymentService;
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
            _httpClient = httpClient;
        }

        public async Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
        {
            var basket = await _basketService.GetAsync();

            var paymentInfoInput = new FakePaymentInfoInput()
            {
                CardName = checkoutInfoInput.CardName,
                CardNumber = checkoutInfoInput.CardNumber,
                Cvv = checkoutInfoInput.Cvv,
                Expiration = checkoutInfoInput.Expiration,
                Price = basket.TotalPrice
            };
            var responsePayment=await _paymentService.ReceivePayment(paymentInfoInput);

            if (!responsePayment)
            {
                return new OrderCreatedViewModel() { Error = "Ödeme alınamadı", IsSuccessfull = false };
            }//14

            throw new System.NotImplementedException();
        }

        public Task<List<OrderViewModel>> GetOrder()
        {
            throw new System.NotImplementedException();
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
