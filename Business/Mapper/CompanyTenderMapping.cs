using AutoMapper;
using Business.DTOs.CompanyTender;
using Domain.Models;

namespace Business.Mapper;

public class CompanyTenderMapping:Profile
{
    public CompanyTenderMapping()
    {
        CreateMap<CompanyTender, CompanyTenderCreateDto>().ReverseMap();
        CreateMap<CompanyTender, CompanyTenderGetDto>().ReverseMap();
        CreateMap<CompanyTender, CompanyTenderUpdateDto>().ReverseMap();
    }
    
}