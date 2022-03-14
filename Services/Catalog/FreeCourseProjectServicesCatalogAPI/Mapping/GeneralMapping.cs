using AutoMapper;
using FreeCourseProjectServicesCatalogAPI.DTOs;
using FreeCourseProjectServicesCatalogAPI.Models;

namespace FreeCourseProjectServicesCatalogAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Feature,FeatureDto>().ReverseMap();

            CreateMap<Course,CourseCreateDto>().ReverseMap();
            CreateMap<Course,CourseUpdateDto>().ReverseMap();
        }
    }
}
