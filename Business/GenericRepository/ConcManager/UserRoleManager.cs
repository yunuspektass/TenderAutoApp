using AutoMapper;
using Business.DTOs.User;
using Business.DTOs.UserRole;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class UserRoleManager : IUserRoleService
{
    private readonly UserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public UserRoleManager(UserRoleRepository userRoleRepository, IMapper mapper , IMailService mailService)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _mailService = mailService;
    }


    public async Task<IEnumerable<UserRoleGetDto>> GetList()
    {
        var userRoles = await _userRoleRepository.GetItems();

        return _mapper.Map<IEnumerable<UserRoleGetDto>>(userRoles);
    }

    public async Task<UserRoleGetDto> GetItem(int id)
    {
        var userRole = await _userRoleRepository.GetItem(id);

        return _mapper.Map<UserRoleGetDto>(userRole);
    }

    public async Task<UserRoleCreateDto> PostItem(UserRoleCreateDto userRoleCreateDto)
    {
        var userRole = _mapper.Map<UserRole>(userRoleCreateDto);

        await _userRoleRepository.Add(userRole);

        await _mailService.SendEmailAsync("test@gmail.com", "Yeni Kullanıcı Rolü Eklendi",
            userRole.UserId + " Numaralı kullanıcı rolü eklendi");

        return _mapper.Map<UserRoleCreateDto>(userRole);
    }

    public async Task<bool> PutItem(int id, UserRoleUpdateDto userRoleUpdateDto)
    {
        var existingUserRole = await _userRoleRepository.GetItem(id);

        if (existingUserRole == null)
        {
            return false;
        }

        _mapper.Map(userRoleUpdateDto, existingUserRole);

        await _userRoleRepository.Update(existingUserRole);

        await _mailService.SendEmailAsync("test@gmail.com", "Kullanıcı Rolü Güncellendi",
            existingUserRole.Id + " Numaralı kullanıcını rolünüz güncellenmiştir.");
        
        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingUserRole = await _userRoleRepository.Find(id);

        if (existingUserRole == null)
        {
            return false;
        }

        await _userRoleRepository.Delete(existingUserRole);

        await _mailService.SendEmailAsync("test@gmail.com", "Kullanıcı Rolü Silindi",
            id + " Numaralı kullanıcını Rolünüz silindi.");

        return true;
    }
}