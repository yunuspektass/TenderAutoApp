using AutoMapper;
using Business.DTOs.Category;
using Domain.Models;

namespace Business.Mapper;

public class CategoryMapping:Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

    }
}