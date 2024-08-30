using AutoMapper;
using Business.DTOs.TenderProduct;
using Business.DTOs.TenderProductListGetDto;
using Domain.Models;

namespace Business.Mapper;

public class TenderProductListMapping:Profile
{
    public TenderProductListMapping()
    {
        CreateMap<TenderProductList, TenderProductListCreateDto>().ReverseMap();
        CreateMap<TenderProductList, TenderProductListGetDto>().ReverseMap();
        CreateMap<TenderProductList, TenderProductListUpdateDto>().ReverseMap();
    }
}