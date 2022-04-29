using FreeCourseProjectWebUI.Models.Discounts;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
