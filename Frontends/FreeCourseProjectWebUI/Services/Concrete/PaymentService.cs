using FreeCourseProjectWebUI.Models.FakePayments;
using FreeCourseProjectWebUI.Services.Abstract;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync<FakePaymentInfoInput>("fakepayments", fakePaymentInfoInput);

            return response.IsSuccessStatusCode;
        }
    }
}
