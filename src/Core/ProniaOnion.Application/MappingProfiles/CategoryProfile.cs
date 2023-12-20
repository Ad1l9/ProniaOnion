using AutoMapper;
using ProniaOnion.Application.Dtos.Category;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
