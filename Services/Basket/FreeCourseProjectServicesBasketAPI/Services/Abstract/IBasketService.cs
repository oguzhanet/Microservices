using FreeCourseProjectServicesBasketAPI.DTOs;
using FreeCourseShared.Concrete;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesBasketAPI.Services.Abstract
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasketByUserId(string userId);

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> DeleteBasketByUserId(string userId);
    }
}
