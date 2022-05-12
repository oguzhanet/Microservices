using FreeCourseProjectServicesBasketAPI.DTOs;
using FreeCourseProjectServicesBasketAPI.Services.Abstract;
using FreeCourseProjectServicesBasketAPI.Services.Concrete;
using FreeCourseShared.Messages;
using MassTransit;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesBasketAPI.Consumers
{
    public class BasketCourseNameChangedEventConsumer:IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisManager _redisManager;

        public BasketCourseNameChangedEventConsumer(RedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var keys = _redisManager.GetKeys();

            if (keys != null)
            {
                foreach (var key in keys)
                {
                    var basket = await _redisManager.GetDb().StringGetAsync(key);

                    var basketDto=JsonSerializer.Deserialize<BasketDto>(basket);

                    basketDto.BasketItems.ForEach(x =>
                    {
                        x.CourseName = x.CourseId == context.Message.CourseId ? context.Message.UpdatedName : x.CourseName;
                    });

                    await _redisManager.GetDb().StringSetAsync(key, JsonSerializer.Serialize(basketDto));
                }
            }
        }
    }
}
