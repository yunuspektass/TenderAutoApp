using AutoMapper;
using Business.DTOs.TenderProduct;
using Domain.Models;

namespace Business.Mapper;

public class TenderProductMapping:Profile
{
    public TenderProductMapping()
    {
        CreateMap<TenderProduct, TenderProductCreateDto>().ReverseMap();
        CreateMap<TenderProduct, TenderProductGetDto>().ReverseMap();
        CreateMap<TenderProduct, TenderProductUpdateDto>().ReverseMap();

    }
    
}