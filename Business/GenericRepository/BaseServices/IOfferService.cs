using Business.DTOs.Offer;
using Domain.Models;

namespace Business.GenericRepository.BaseServices;

public interface IOfferService
{
    Task<IEnumerable<OfferGetDto>> GetList();

    Task<OfferGetDto> GetItem(int id);

    Task<OfferCreateDto> PostItem(OfferCreateDto offerCreateDto);

    Task<bool> PutItem(int id, OfferUpdateDto offerUpdateDto);

    Task<bool> DeleteItem(int id);
}