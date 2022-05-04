using FreeCourseProjectWebUI.Models.FakePayments;
using FreeCourseProjectWebUI.Models.Orders;
using FreeCourseProjectWebUI.Services.Abstract;
using FreeCourseShared.Concrete;
using FreeCourseShared.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
            var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

            if (!responsePayment)
            {
                return new OrderCreatedViewModel() { Error = "Ödeme alınamadı", IsSuccessfull = false };
            }

            var orderCreateInput = new OrderCreateInput()
            {
                BuyerId = _sharedIdentityService.GetUserId,
                Address = new AddressCreateInput
                {
                    District = checkoutInfoInput.District,
                    Line = checkoutInfoInput.Line,
                    Province = checkoutInfoInput.Province,
                    Street = checkoutInfoInput.Street,
                    ZipCode = checkoutInfoInput.ZipCode,
                },
            };

            basket.BasketItems.ForEach(x =>
            {
                var orderItem = new OrderItemCreateInput
                {
                    ProductId = x.CourseId,
                    ProductName = x.CourseName,
                    ProductPrice = x.GetCurrentPrice,
                    PictureUrl = ""
                };

                orderCreateInput.OrderItems.Add(orderItem);
            });

            var response = await _httpClient.PostAsJsonAsync<OrderCreateInput>("orders", orderCreateInput);

            if (!response.IsSuccessStatusCode)
            {
                return new OrderCreatedViewModel() { Error = "Sipariş oluştulamadı", IsSuccessfull = false };
            }
            //var responseString=response.Content.ReadAsStringAsync();
            var orderCreatedViewModel = await response.Content.ReadFromJsonAsync<Response<OrderCreatedViewModel>>();

            orderCreatedViewModel.Data.IsSuccessfull = true;

            await _basketService.DeleteAsync();

            return orderCreatedViewModel.Data;
        }

        public async Task<List<OrderViewModel>> GetOrder()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders");

            return response.Data;
        }

        public async Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            var basket = await _basketService.GetAsync();

            var orderCreateInput = new OrderCreateInput()
            {
                BuyerId = _sharedIdentityService.GetUserId,
                Address = new AddressCreateInput
                {
                    District = checkoutInfoInput.District,
                    Line = checkoutInfoInput.Line,
                    Province = checkoutInfoInput.Province,
                    Street = checkoutInfoInput.Street,
                    ZipCode = checkoutInfoInput.ZipCode,
                },
            };

            basket.BasketItems.ForEach(x =>
            {
                var orderItem = new OrderItemCreateInput
                {
                    ProductId = x.CourseId,
                    ProductName = x.CourseName,
                    ProductPrice = x.GetCurrentPrice,
                    PictureUrl = ""
                };

                orderCreateInput.OrderItems.Add(orderItem);
            });

            var paymentInfoInput = new FakePaymentInfoInput()
            {
                CardName = checkoutInfoInput.CardName,
                CardNumber = checkoutInfoInput.CardNumber,
                Cvv = checkoutInfoInput.Cvv,
                Expiration = checkoutInfoInput.Expiration,
                Price = basket.TotalPrice,
                Order = orderCreateInput
            };

            var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

            if (!responsePayment)
            {
                return new OrderSuspendViewModel() { Error = "Ödeme alınamadı", IsSuccessfull = false };
            }

            await _basketService.DeleteAsync();

            return new OrderSuspendViewModel() { IsSuccessfull = true };
        }
    }
}
