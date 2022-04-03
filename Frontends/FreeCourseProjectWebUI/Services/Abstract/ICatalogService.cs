using FreeCourseProjectWebUI.Models.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Abstract
{
    public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCourseAsync();

        Task<List<CategoryViewModel>> GetAllCategoriesAsync();

        Task<List<CourseViewModel>> GetAllCourseByUserIdAsync(string userId);  

        Task<CourseViewModel> GetByCourseIdAsync(string courseId);

        Task<bool> CreateCourseAsync(CourseCreateInput courseCreateInput);
        
        Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput);

        Task<bool> DeleteCourseAsync(string courseId);
    }
}
