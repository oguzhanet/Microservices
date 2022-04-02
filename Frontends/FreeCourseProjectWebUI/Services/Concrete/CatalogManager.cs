using FreeCourseProjectWebUI.Models;
using FreeCourseProjectWebUI.Models.Catalog;
using FreeCourseProjectWebUI.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Services.Concrete
{
    public class CatalogManager : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateCourseAsync(CourseCreateInput courseCreateInput)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCourseAsync(string courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CourseViewModel>> GetAllCourseAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CourseViewModel>> GetAllCourseByUserIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CourseViewModel> GetByCourseIdAsync(string courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
