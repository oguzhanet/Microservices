using FreeCourseProjectServicesDiscountAPI.Models;
using FreeCourseShared.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesDiscountAPI.Services.Abstract
{
    public interface IDiscountService
    {
        Task<Response<List<Discount>>> GetAllAsync();
        Task<Response<Discount>> GetByIdAsync(int id);
        Task<Response<NoContent>> CreateAsync(Discount discount);
        Task<Response<NoContent>> UpdateAsync(Discount discount);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<Discount>> GetByCodeAndUserIdAsync(string code, string userId);
    }
}
