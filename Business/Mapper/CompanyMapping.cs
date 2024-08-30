using AutoMapper;
using Business.DTOs.Company;
using Domain.Models;

namespace Business.Mapper;

public class CompanyMapping:Profile
{
    public CompanyMapping()
    {
        CreateMap<Company, CompanyCreateDto>().ReverseMap();
        CreateMap<Company, CompanyUpdateDto>().ReverseMap();
        CreateMap<Company, CompanyGetDto>().ReverseMap();
    }
}