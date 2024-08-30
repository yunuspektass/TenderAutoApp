using AutoMapper;
using Business.DTOs.Offer;
using Domain.Models;

namespace Business.Mapper;

public class OfferMapping:Profile
{
    public OfferMapping()
    {
        CreateMap<Offer, OfferCreateDto>().ReverseMap();
        CreateMap<Offer, OfferGetDto>().ReverseMap();
        CreateMap<Offer, OfferUpdateDto>().ReverseMap();
    }
    
}