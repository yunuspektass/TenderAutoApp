using AutoMapper;
using Business.DTOs.Tender;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class TenderManager:ITenderService
{
    private readonly TenderRepository _tenderRepository;
    private readonly TenderProductRepository _tenderProductRepository;
    private readonly TenderProductListRepository _tenderProductListRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public TenderManager(TenderRepository tenderRepository , IMapper mapper , IMailService mailService , TenderProductRepository tenderProductRepository, TenderProductListRepository tenderProductListRepository)
    {
        _tenderRepository = tenderRepository;
        _mapper = mapper;
        _mailService = mailService;
        _tenderProductRepository = tenderProductRepository;
        _tenderProductListRepository = tenderProductListRepository;
    }
    
    
       
    public async Task<IEnumerable<TenderGetDto>> GetList()
    {
        var tenders = await _tenderRepository.GetItems();
        var tenderDtos = _mapper.Map<List<TenderGetDto>>(tenders);
        return tenderDtos;
    }

    public async Task<TenderGetDto> GetItem(int id)
    {
        var tender = await _tenderRepository.GetItem(id);

        if (tender == null)
        {
            return null;
        }

        var tenderDto = _mapper.Map<TenderGetDto>(tender);

        return tenderDto;
    }

    public async Task<TenderCreateDto> PostItem(TenderCreateDto tenderCreateDto)
    {
        var tender = _mapper.Map<Tender>(tenderCreateDto);
        await _tenderRepository.Add(tender);

        if (tenderCreateDto.TenderProductLists != null)
        {
            foreach (var product in tenderCreateDto.TenderProductLists)
            {
                var tenderProductList = new TenderProductList
                {
                    TenderId = tender.Id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    TotalPrice = product.TotalPrice,
                    TenderDuration = product.TenderDuration,
                    TenderEntryDate = product.TenderEntryDate,
                    CategoryId = product.CategoryId
                };
                await _tenderProductListRepository.Add(tenderProductList);
            }
        }

        if (tenderCreateDto.ProductIds != null)
        {
            foreach (var productId in tenderCreateDto.ProductIds)
            {
                var tenderProduct = new TenderProduct
                {
                    TenderId = tender.Id,
                    ProductId = productId
                };
                await _tenderProductRepository.Add(tenderProduct);
            }
        }

        var resultDto = _mapper.Map<TenderCreateDto>(tender);
        await _mailService.SendEmailAsync("test@gmail.com", "İhale Eklendi",
            tenderCreateDto.Title + " İsimli ihale listenize eklenmiştir");

        return resultDto;
    }

    public async Task<bool> PutItem(int id, TenderUpdateDto tenderUpdateDto)
    {
        var existingProduct = await _tenderRepository.GetItem(id);

        if (existingProduct == null)
        {
            return false;
        }

        _mapper.Map(tenderUpdateDto, existingProduct);
        await _tenderRepository.Update(existingProduct);

        var existingTenderProducts = await _tenderProductRepository.GetTenderProducts(id);

        foreach (var existingTenderProduct in existingTenderProducts)
        {
            existingTenderProduct.Deleted = true;
            await _tenderProductRepository.Update(existingTenderProduct);
        }

        if (tenderUpdateDto.TenderProductLists != null)
        {
            foreach (var product in tenderUpdateDto.TenderProductLists)
            {
                var newTenderProductList = new TenderProductList
                {
                    TenderId = id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    TotalPrice = product.TotalPrice,
                    TenderDuration = product.TenderDuration,
                    TenderEntryDate = product.TenderEntryDate,
                    CategoryId = product.CategoryId,
                    Deleted = false
                };
                await _tenderProductListRepository.Add(newTenderProductList);
            }
        }

        if (tenderUpdateDto.ProductIds != null)
        {
            foreach (var productId in tenderUpdateDto.ProductIds)
            {
                var newTenderProduct = new TenderProduct
                {
                    TenderId = id,
                    ProductId = productId,
                    Deleted = false
                };
                await _tenderProductRepository.Add(newTenderProduct);
            }
        }

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Güncelleme",
            tenderUpdateDto.Id + " Numaralı ihale listenizde güncellenmiştir.");

        return true;
    }
    public async Task<bool> DeleteItem(int id)
    {
        var existingProduct = await _tenderRepository.Find(id);

        if (existingProduct == null)
        {
            return false;
        }

        await _tenderRepository.Delete(existingProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Silindi",
            id + " Numaralı ihale listenizden silinmiştir");

        return true;
    }
}