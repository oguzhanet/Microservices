﻿using FreeCourseProjectWebUI.Models.Baskets;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IBasketService
    {
        Task<bool> SaveOrUpdateAsync(BasketViewModel basketViewModel);

        Task<BasketViewModel> GetAsync();

        Task<bool> DeleteAsync();

        Task AddBasketItemAsync(BasketItemViewModel basketItemViewModel);

        Task<bool> RemoveBasketItemAsync(string courseId);
        
        Task<bool> ApplyDiscountAsync(string discountCode);

        Task<bool> CancelApplyDiscountAsync();
    }
}
