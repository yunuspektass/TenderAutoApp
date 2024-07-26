using AutoMapper;
using Business.DTOs.Company;
using Business.GenericRepository.BaseRep;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class CompanyManager:ICompanyService
{
    private readonly CompanyRepository _companyRepository;
    private readonly CompanyTenderRepository _companyTenderRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public CompanyManager(CompanyRepository companyRepository , IMapper mapper , IMailService mailService , CompanyTenderRepository companyTenderRepository)
    {
        _companyRepository = companyRepository;
        _companyTenderRepository = companyTenderRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    
    public async Task<IEnumerable<CompanyGetDto>> GetList()
    {
        var companies = await _companyRepository.GetItems();

        return _mapper.Map<IEnumerable<CompanyGetDto>>(companies);
    }

    public async Task<CompanyGetDto> GetItem(int id)
    {
        var company = await _companyRepository.GetItem(id);

        return _mapper.Map<CompanyGetDto>(company);
    }

    public async Task<CompanyCreateDto> PostItem(CompanyCreateDto companyCreateDto)
    {
        var company = _mapper.Map<Company>(companyCreateDto);
        await _companyRepository.Add(company);

        if (companyCreateDto.TenderIds != null)
        {
           foreach (var tenderId in companyCreateDto.TenderIds)
           {
               var companyTender = new CompanyTender
               {
                    CompanyId = company.Id,
                    TenderId = tenderId,
                    AwardedAmount = 0,
                    CreatedBy = "system",
                    UpdatedBy = "system",
                    Deleted = false 
               };
               await _companyTenderRepository.Add(companyTender);
           } 
        }

        await _mailService.SendEmailAsync("test@gmail.com ", "Şirket Eklendi"
            , company.CompanyName + " İsimli şirket listenize eklenmiştir.");

        return _mapper.Map<CompanyCreateDto>(company);
    }

    public async Task<bool> PutItem(int id, CompanyUpdateDto companyUpdateDto)
    {
        var existingCompany = await _companyRepository.GetItem(id);

        if (existingCompany == null)
        {
            return false;
        }

        var existingCompanyTenders = await _companyTenderRepository.GetCompanyTendersByCompanyId(id);

        foreach (var companyTender in existingCompanyTenders)
        {
            await _companyTenderRepository.Delete(companyTender);
        }

        if (companyUpdateDto.TenderIds != null)
        {
            foreach (var tenderId in companyUpdateDto.TenderIds)
            {
                var companyTender = new CompanyTender
                {
                    CompanyId = id,
                    TenderId = tenderId,
                    AwardedAmount = 0,
                    CreatedBy = "system",
                    UpdatedBy = "system",
                    Deleted = false
                };
                await _companyTenderRepository.Add(companyTender);
            }
        }
        
        _mapper.Map(companyUpdateDto, existingCompany);

        await _companyRepository.Update(existingCompany);

        await _mailService.SendEmailAsync("test@gmail.com", "Şirket Güncellendi",
            id + " Numaralı şirket listenizde güncellenmiştir");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingCompany = await _companyRepository.Find(id);

        if (existingCompany == null)
        {
            return false;
        }

        await _companyRepository.Delete(existingCompany);

        await _mailService.SendEmailAsync("test@gmail.com", "Şirket Silindi",
            id + " Numaralı şirket listenizden silinmiştir");

        return true;
    }
}