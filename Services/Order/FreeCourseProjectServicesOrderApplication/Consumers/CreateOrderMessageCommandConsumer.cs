using FreeCourseProjectServicesOrderDomain.OrderAggregate;
using FreeCourseProjectServicesOrderInfrastructure;
using FreeCourseShared.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesOrderApplication.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderMessageCommandConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Address(context.Message.Province, context.Message.District, context.Message.Street, context.Message.ZipCode, context.Message.Line);

            Order order = new Order(newAddress, context.Message.BuyerId);

            context.Message.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(x.ProductId, x.ProductName, x.ProductPrice, x.PictureUrl);
            });

            await _orderDbContext.Orders.AddAsync(order);
            await _orderDbContext.SaveChangesAsync();
        }
    }
}
