using FreeCourseProjectWebUI.Models.Basket;
using FreeCourseProjectWebUI.Services.Abstract;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddBasketItemAsync(BasketItemViewModel basketItemViewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ApplyDiscount(string discountCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CancelApplyDiscount()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BasketViewModel> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveBasketItem(string courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveOrUpdateAsync(BasketViewModel basketViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
