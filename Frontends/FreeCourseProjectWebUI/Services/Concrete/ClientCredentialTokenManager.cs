using FreeCourseProjectWebUI.Models;
using FreeCourseProjectWebUI.Services.Abstract;
using IdentityModel.AspNetCore.AccessTokenManagement;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class ClientCredentialTokenManager : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly ClientAccessTokenCache _clientAccessTokenCache;

        public ClientCredentialTokenManager(IOptions<ServiceApiSettings> serviceApiSettings, IOptions<ClientSettings> clientSettings, ClientAccessTokenCache clientAccessTokenCache)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _clientSettings = clientSettings.Value;
            _clientAccessTokenCache = clientAccessTokenCache;
        }

        public Task<string> GetToken()
        {
            throw new System.NotImplementedException();
        }
    }
}
