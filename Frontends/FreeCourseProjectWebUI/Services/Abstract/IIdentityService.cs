using FreeCourseProjectWebUI.Models;
using FreeCourseShared.Concrete;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SingInInput singInInput);

        Task<TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}
