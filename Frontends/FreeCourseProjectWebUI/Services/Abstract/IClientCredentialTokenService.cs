using System;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<String> GetToken();
    }
}
