using AutoMapper;
using Business.DTOs.Tender;
using Domain.Models;

namespace Business.Mapper;

public class TenderMapping:Profile
{
    public TenderMapping()
    {
        CreateMap<Tender, TenderCreateDto>().ReverseMap();
        CreateMap<Tender, TenderGetDto>().ReverseMap();
        CreateMap<Tender, TenderUpdateDto>().ReverseMap();
    }
}