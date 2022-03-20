using FreeCourseProjectServicesDiscountAPI.Models;
using FreeCourseProjectServicesDiscountAPI.Services.Abstract;
using FreeCourseShared.ControllerBases;
using FreeCourseShared.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesDiscountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountsController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var discounts = await _discountService.GetAllAsync();

            return CreateActionResultInstance(discounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);

            return CreateActionResultInstance(discount);
        }

        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;
            var discount = await _discountService.GetByCodeAndUserIdAsync(code, userId);

            return CreateActionResultInstance(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discount discoubt)
        {
            var result = await _discountService.CreateAsync(discoubt);

            return CreateActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Discount discount)
        {
            var result = await _discountService.UpdateAsync(discount);

            return CreateActionResultInstance(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _discountService.DeleteAsync(id);

            return CreateActionResultInstance(result);
        }
    }
}
