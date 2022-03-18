using FreeCourseProjectServicesBasketAPI.DTOs;
using FreeCourseProjectServicesBasketAPI.Services.Abstract;
using FreeCourseShared.ControllerBases;
using FreeCourseShared.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesBasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var result = await _basketService.GetBasketByUserId(_sharedIdentityService.GetUserId);

            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            var response = await _basketService.SaveOrUpdate(basketDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var result = await _basketService.DeleteBasketByUserId(_sharedIdentityService.GetUserId);

            return CreateActionResultInstance(result);
        }
    }
}
