using AutoMapper;
using Business.DTOs.TenderProduct;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class TenderProductManager:ITenderProductService
{
   
   private readonly TenderProductRepository _tenderProductRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public TenderProductManager(TenderProductRepository tenderProductRepository , IMapper mapper , IMailService mailService)
    {
        _tenderProductRepository = tenderProductRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    
    public async Task<IEnumerable<TenderProductGetDto>> GetList()
    {
        var tenderProducts = await _tenderProductRepository.GetItems();

        return _mapper.Map<IEnumerable<TenderProductGetDto>>(tenderProducts);
    }

    public async Task<TenderProductGetDto> GetItem(int id)
    {
        var tenderProduct = await _tenderProductRepository.GetItem(id);

        return _mapper.Map<TenderProductGetDto>(tenderProduct);
    }

    public async Task<TenderProductCreateDto> PostItem(TenderProductCreateDto tenderProductCreateDto)
    {
        var tenderProduct = _mapper.Map<TenderProduct>(tenderProductCreateDto);

        await _tenderProductRepository.Add(tenderProduct);

        await _mailService.SendEmailAsync("test@gmail.com ", "İhale Ürün İlişkisi Eklendi"
            , tenderProduct.Tender + " "  +tenderProduct.Product + " İsimli ihale ve ürün ilişkiniz listenize eklenmiştir.");

        return _mapper.Map<TenderProductCreateDto>(tenderProduct);
    }

    public async Task<bool> PutItem(int id, TenderProductUpdateDto tenderProductUpdateDto)
    {
        var existingTenderProduct = await _tenderProductRepository.GetItem(id);

        if (existingTenderProduct == null)
        {
            return false;
        }

        _mapper.Map(tenderProductUpdateDto, existingTenderProduct);

        await _tenderProductRepository.Update(existingTenderProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Ürün İlişkisi Listesi Güncellendi",
            id + " Numaralı ürün ihale ilişkiniz güncellenmiştir");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingCompany = await _tenderProductRepository.Find(id);

        if (existingCompany == null)
        {
            return false;
        }

        await _tenderProductRepository.Delete(existingCompany);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Ürün İlişkisi Silindi",
            id + " Numaralı ürün ihale ilişkiniz listenizden silinmiştir");

        return true;
    }
}