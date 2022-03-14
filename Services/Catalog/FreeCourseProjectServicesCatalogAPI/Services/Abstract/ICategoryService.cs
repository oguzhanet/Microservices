using FreeCourseProjectServicesCatalogAPI.DTOs;
using FreeCourseProjectServicesCatalogAPI.Models;
using FreeCourseShared.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesCatalogAPI.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
    }
}
