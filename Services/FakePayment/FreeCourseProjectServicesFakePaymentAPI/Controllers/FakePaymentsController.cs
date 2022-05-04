using FreeCourseProjectServicesFakePaymentAPI.Models;
using FreeCourseShared.Concrete;
using FreeCourseShared.ControllerBases;
using FreeCourseShared.Messages;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesFakePaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        private readonly ISendEndpointProvider _sendEndpointProvider; // for send
        // private readonly IPublishEndpointProvider _publishEndpointProvider; // for event

        public FakePaymentsController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePayment(FakePaymentDto fakePaymentDto)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            var createOrderMessageCommand = new CreateOrderMessageCommand();

            createOrderMessageCommand.BuyerId = fakePaymentDto.Order.BuyerId;
            createOrderMessageCommand.Province = fakePaymentDto.Order.Address.Province;
            createOrderMessageCommand.District = fakePaymentDto.Order.Address.District;
            createOrderMessageCommand.Street = fakePaymentDto.Order.Address.Street;
            createOrderMessageCommand.Line = fakePaymentDto.Order.Address.Line;

            fakePaymentDto.Order.OrderItems.ForEach(x =>
            {
                createOrderMessageCommand.OrderItems.Add(new OrderItem
                {
                    PictureUrl = x.PictureUrl,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice
                });
            });

            await sendEndpoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);

            return CreateActionResultInstance(FreeCourseShared.Concrete.Response<NoContent>.Success(200));
        }
    }
}
