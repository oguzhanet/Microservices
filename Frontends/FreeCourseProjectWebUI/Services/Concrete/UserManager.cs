using FreeCourseProjectWebUI.Models;
using FreeCourseProjectWebUI.Services.Abstract;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserViewModel> GetUser()
        {
            var user = await _httpClient.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
            return user;
        }
    }
}
