using AutoMapper;
using Business.DTOs.Product;
using Business.DTOs.Urun;
using Domain.Models;

namespace Business.Mapper;

public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<Product , ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
    }
    
}