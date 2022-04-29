using FreeCourseProjectWebUI.Models.FakePayments;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfoInput);
    }
}
