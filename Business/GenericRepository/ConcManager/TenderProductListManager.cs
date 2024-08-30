using AutoMapper;
using Business.DTOs.TenderProductListGetDto;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class TenderProductListManager:ITenderProductListService
{
   private readonly TenderProductListRepository _tenderProductListRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public TenderProductListManager(TenderProductListRepository tenderProductListRepository , IMapper mapper , IMailService mailService)
    {
        _tenderProductListRepository = tenderProductListRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    
    public async Task<IEnumerable<TenderProductListGetDto>> GetList()
    {
        var tenderProductLists = await _tenderProductListRepository.GetItems();

        return _mapper.Map<IEnumerable<TenderProductListGetDto>>(tenderProductLists);
    }

    public async Task<TenderProductListGetDto> GetItem(int id)
    {
        var tenderProductList = await _tenderProductListRepository.GetItem(id);

        return _mapper.Map<TenderProductListGetDto>(tenderProductList);
    }

    public async Task<TenderProductListCreateDto> PostItem(TenderProductListCreateDto tenderProductListCreateDto)
    {
        var tenderProductList = _mapper.Map<TenderProductList>(tenderProductListCreateDto);

        await _tenderProductListRepository.Add(tenderProductList);

        await _mailService.SendEmailAsync("test@gmail.com ", "İhale Ürünü Eklendi"
            , tenderProductList.ProductName + " İsimli ihalelere özel ürün listenize eklenmiştir.");

        return _mapper.Map<TenderProductListCreateDto>(tenderProductList);
    }

    public async Task<bool> PutItem(int id, TenderProductListUpdateDto tenderProductListUpdateDto)
    {
        var existingTenderProductList = await _tenderProductListRepository.GetItem(id);

        if (existingTenderProductList == null)
        {
            return false;
        }

        _mapper.Map(tenderProductListUpdateDto, existingTenderProductList);

        await _tenderProductListRepository.Update(existingTenderProductList);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Ürün Listesi Güncellendi",
            id + " Numaralı ürün ,  ihalelere özel ürün listenizde güncellenmiştir");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingCompany = await _tenderProductListRepository.Find(id);

        if (existingCompany == null)
        {
            return false;
        }

        await _tenderProductListRepository.Delete(existingCompany);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Ürünü Silindi",
            id + " Numaralı ihalelere özel ürün listenizden silinmiştir");

        return true;
    }
}