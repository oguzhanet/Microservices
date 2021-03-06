using FreeCourseProjectWebUI.Models.PhotoStocks;
using FreeCourseProjectWebUI.Services.Abstract;
using FreeCourseShared.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class PhotoStockService : IPhotoStockService
    {
        private readonly HttpClient _httpClient;

        public PhotoStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePhotoAsync(string photoUrl)
        {
            var response = await _httpClient.DeleteAsync($"photos?photoUrl={photoUrl}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PhotoViewModel> UploadPhotoAsync(IFormFile photo)
        {
            string[] validImageFileTypes = { ".JPG", ".JPEG", ".PNG" };
            bool isValidFileExtension = validImageFileTypes.Any(t => t == Path.GetExtension(photo.FileName).ToUpper());

            if (photo == null || photo.Length <= 0 || isValidFileExtension == false)
            {
                return null;
            }

            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

            using var memoryStream = new MemoryStream();

            await photo.CopyToAsync(memoryStream);

            var multipartContent = new MultipartFormDataContent();

            multipartContent.Add(new ByteArrayContent(memoryStream.ToArray()), "photo", randomFileName);

            var response = await _httpClient.PostAsync("photos", multipartContent);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<PhotoViewModel>>();

            return responseSuccess.Data;
        }
    }
}
