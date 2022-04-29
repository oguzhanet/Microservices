using FreeCourseProjectWebUI.Models.PhotoStocks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface IPhotoStockService
    {
        Task<PhotoViewModel> UploadPhotoAsync(IFormFile photo);

        Task<bool> DeletePhotoAsync(string photoUrl);
    }
}
