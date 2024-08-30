using AutoMapper;
using Business.DTOs.UserCompany;
using Business.DTOs.UserTender;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class UserCompanyManager:IUserCompanyService
{

    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IHashingService _hashingService;
    private readonly UserCompanyRepository _userCompanyRepository;

    public UserCompanyManager( IMapper mapper, IMailService mailService,
        IHashingService hashingService, UserCompanyRepository userCompanyRepository)
    {
        _mapper = mapper;
        _mailService = mailService;
        _hashingService = hashingService;
        _userCompanyRepository = userCompanyRepository;
    }


    public async Task<IEnumerable<UserCompanyGetDto>> GetList()
    {
        var userCompanies = await _userCompanyRepository.GetItems();

        return _mapper.Map<IEnumerable<UserCompanyGetDto>>(userCompanies);
    }

    public async Task<UserCompanyGetDto> GetItem(int id)
    {
        var userCompany = await _userCompanyRepository.GetItem(id);
        return _mapper.Map<UserCompanyGetDto>(userCompany);
    }

    public async Task<UserCompany> PostItem(UserCompanyCreateDto userCompanyCreateDto)
    {
            var existingUserCompany = await _userCompanyRepository.FindUserCompany(userCompanyCreateDto.UserId, userCompanyCreateDto.CompanyId);
            if (existingUserCompany != null)
            {
                throw new Exception("Bu kullanıcı zaten bu şirketin sorumlusu.");
            }

            var userCompany = _mapper.Map<UserCompany>(userCompanyCreateDto);

            await _userCompanyRepository.Add(userCompany);

            await _mailService.SendEmailAsync("test@gmail.com", "Şirket Sorumlusu Eklendi",
                $"Company ID: {userCompanyCreateDto.CompanyId} numaralı şirketten sorumlu olarak atanmış bulunmaktasınız.");

            return userCompany;
    }

    public async Task<bool> PutItem(int id, UserCompanyUpdateDto userCompanyUpdateDto)
    {

        var existingUser = await _userCompanyRepository.GetItem(id);

        if (existingUser == null)
        {
            return false;
        }

        _mapper.Map(userCompanyUpdateDto, existingUser);

        await _userCompanyRepository.Update(existingUser);


        await _mailService.SendEmailAsync("test@gmail.com", "Şirket Sorumlusu Güncellendi",
            existingUser.Id + " Numaralı şirket sorumlunuz güncellenmiştir.");

        return true;

    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingUser = await _userCompanyRepository.Find(id);

        if (existingUser == null)
        {
            return false;
        }

        await _userCompanyRepository.Delete(existingUser);

        await _mailService.SendEmailAsync("test@gmail.com", "Şirket Sorumlusu Silindi",
            id + " Numaralı şirket sorumlusu silindi.");

        return true;
    }

    public async Task<bool> DeleteUserCompaniesByUserId(int userId)
    {
        var userCompanies = await _userCompanyRepository.GetByUserId(userId);

        if (userCompanies == null || !userCompanies.Any())
        {
            return false;
        }

        await _userCompanyRepository.DeleteRange(userCompanies);

        await _mailService.SendEmailAsync("test@gmail.com", "Şirket Sorumlulukları Silindi",
            userId + " Numaralı kullanıcının tüm şirket sorumlulukları güncellenmek için silindi ve eklendi.");

        return true;
    }

}
