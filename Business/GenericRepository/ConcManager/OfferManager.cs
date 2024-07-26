using AutoMapper;
using Business.DTOs.Offer;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class OfferManager:IOfferService
{
    private readonly OfferRepository _offerRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public OfferManager(OfferRepository offerRepository , IMapper mapper , IMailService mailService)
    {
        _offerRepository = offerRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    public async Task<IEnumerable<OfferGetDto>> GetList()
    {
        var offers = await _offerRepository.GetItems();

        return _mapper.Map<IEnumerable<OfferGetDto>>(offers);
    }

    public async  Task<OfferGetDto> GetItem(int id)
    {
        var offer = await _offerRepository.GetItem(id);

        return _mapper.Map<OfferGetDto>(offer);
    }

    public async Task<OfferCreateDto> PostItem(OfferCreateDto offerCreateDto)
    {
        var offer = _mapper.Map<Offer>(offerCreateDto);

        await _offerRepository.Add(offer);

        await _mailService.SendEmailAsync("test@gmail.com", "Yeni Teklif Eklendi",
            offer.LowestOffer1 + " " + offer.LowestOffer2 + " " + offer.LowestOffer3 + " Teklifler Lsitenize Eklendi");

        return _mapper.Map<OfferCreateDto>(offer);

    }

    public async Task<bool> PutItem(int id, OfferUpdateDto offerUpdateDto)
    {
        var existingOffer = await _offerRepository.GetItem(id);

        if (existingOffer == null)
        {
            return false;
        }

        _mapper.Map(offerUpdateDto, existingOffer);

        await _offerRepository.Update(existingOffer);

        await _mailService.SendEmailAsync("test@gmail.com", "Teklif Güncellendi",
            existingOffer.LowestOffer1 + " " + existingOffer.LowestOffer2 + " " + existingOffer.LowestOffer3 +
            " Teklifler Güncellendi");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingOffer = await _offerRepository.Find(id);

        if (existingOffer == null)
        {
            return false;
        }

        await _offerRepository.Delete(existingOffer);

        await _mailService.SendEmailAsync("test@gmail.com", " Teklif Silindi",
            id + " Numaralı teklif silindi.");

        return true;

    }
}