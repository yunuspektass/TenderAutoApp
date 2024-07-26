using AutoMapper;
using Business.DTOs.TenderStatus;
using Domain.Models;

namespace Business.Mapper;

public class TenderStatusMapping:Profile
{
    public TenderStatusMapping()
    {
        CreateMap<TenderStatus, TenderStatusUpdateDto>().ReverseMap();
        CreateMap<TenderStatus, TenderStatusCreateDto>().ReverseMap();
        CreateMap<TenderStatus, TenderStatusGetDto>().ReverseMap();
    }
}