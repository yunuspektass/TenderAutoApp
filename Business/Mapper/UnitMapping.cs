using AutoMapper;
using Business.DTOs.Unit;
using Domain.Models;

namespace Business.Mapper;

public class UnitMapping:Profile
{
    public UnitMapping()
    {
        CreateMap<Unit, UnitCreateDto>().ReverseMap();
        CreateMap<Unit, UnitGetDto>().ReverseMap();
        CreateMap<Unit, UnitUpdateDto>().ReverseMap();
    }
}