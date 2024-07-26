using AutoMapper;
using Business.DTOs.CompanyTender;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class CompanyTenderManager:ICompanyTenderService
{
  private readonly CompanyTenderRepository _companyTenderRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public CompanyTenderManager(CompanyTenderRepository companyTenderRepository , IMapper mapper , IMailService mailService)
    {
        _companyTenderRepository = companyTenderRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    
    public async Task<IEnumerable<CompanyTenderGetDto>> GetList()
    {
        var companiesTender = await _companyTenderRepository.GetItems();

        return _mapper.Map<IEnumerable<CompanyTenderGetDto>>(companiesTender);
    }

    public async Task<CompanyTenderGetDto> GetItem(int id)
    {
        var companyTender = await _companyTenderRepository.GetItem(id);

        return _mapper.Map<CompanyTenderGetDto>(companyTender);
    }

    public async Task<CompanyTenderCreateDto> PostItem(CompanyTenderCreateDto companyTenderCreateDto)
    {
        var companyTender = _mapper.Map<CompanyTender>(companyTenderCreateDto);

        await _companyTenderRepository.Add(companyTender);

        await _mailService.SendEmailAsync("test@gmail.com ", "Şirket ve İhale Tablonuza Eklendi"
            , companyTender.TenderId + " " +companyTender.CompanyId + " Numaralı şirket ve ihale listenize eklenmiştir.");

        return _mapper.Map<CompanyTenderCreateDto>(companyTender);
    }

    public async Task<bool> PutItem(int id, CompanyTenderUpdateDto companyTenderUpdateDto)
    {
        var existingCompanyTender = await _companyTenderRepository.GetItem(id);

        if (existingCompanyTender == null)
        {
            return false;
        }

        _mapper.Map(companyTenderUpdateDto, existingCompanyTender);

        await _companyTenderRepository.Update(existingCompanyTender);

        await _mailService.SendEmailAsync("test@gmail.com", "Şirket ve İhale Güncellendi",
            id + " Numaralı şirket ve ihale listenizde güncellenmiştir");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingCompany = await _companyTenderRepository.Find(id);

        if (existingCompany == null)
        {
            return false;
        }

        await _companyTenderRepository.Delete(existingCompany);

        await _mailService.SendEmailAsync("test@gmail.com", "Şirket Silindi",
            id + " Numaralı şirket ve ihale listenizden silinmiştir");

        return true;
    }
}