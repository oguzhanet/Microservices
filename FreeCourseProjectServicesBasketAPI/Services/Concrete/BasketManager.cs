using FreeCourseProjectServicesBasketAPI.DTOs;
using FreeCourseProjectServicesBasketAPI.Services.Abstract;
using FreeCourseShared.Concrete;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesBasketAPI.Services.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly RedisManager _redisManager;

        public BasketManager(RedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public async Task<Response<bool>> DeleteBasketByUserId(string userId)
        {
            var status = await _redisManager.GetDb().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404);
        }

        public async Task<Response<BasketDto>> GetBasketByUserId(string userId)
        {
            var existBasket = await _redisManager.GetDb().StringGetAsync(userId);

            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket not found", 404);
            }

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisManager.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500);
        }
    }
}
