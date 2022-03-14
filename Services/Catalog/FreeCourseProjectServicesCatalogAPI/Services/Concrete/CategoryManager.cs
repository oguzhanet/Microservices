using AutoMapper;
using FreeCourseProjectServicesCatalogAPI.DTOs;
using FreeCourseProjectServicesCatalogAPI.Models;
using FreeCourseProjectServicesCatalogAPI.Services.Abstract;
using FreeCourseProjectServicesCatalogAPI.Settings;
using FreeCourseShared.Concrete;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesCatalogAPI.Services.Concrete
{
    public class CategoryManager: ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryMongoCollection;

        private readonly IMapper _mapper;

        public CategoryManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryMongoCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryMongoCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryMongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category=_mapper.Map<Category>(categoryDto);
            await _categoryMongoCollection.InsertOneAsync(category);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

    }
}
