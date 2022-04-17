using FreeCourseProjectWebUI.Models.Basket;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IBasketService
    {
        Task<bool> SaveOrUpdateAsync(BasketViewModel basketViewModel);

        Task<BasketViewModel> GetAsync();

        Task<bool> DeleteAsync();

        Task AddBasketItemAsync(BasketItemViewModel basketItemViewModel);

        Task<bool> RemoveBasketItem(string courseId);
        
        Task<bool> ApplyDiscount(string discountCode);

        Task<bool> CancelApplyDiscount();
    }
}
