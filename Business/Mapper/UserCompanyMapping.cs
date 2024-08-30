using AutoMapper;
using Business.DTOs.UserCompany;
using Domain.Models;

namespace Business.Mapper;

public class UserCompanyMapping:Profile
{
    public UserCompanyMapping()
    {
        CreateMap<UserCompany, UserCompanyCreateDto>().ReverseMap();
        CreateMap<UserCompany, UserCompanyGetDto>().ReverseMap();
        CreateMap<UserCompany, UserCompanyUpdateDto>().ReverseMap();
    }

}
