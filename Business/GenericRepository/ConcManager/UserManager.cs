using AutoMapper;
using Business.DTOs.User;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcManager;

public class UserManager:IUserService
{
     private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IHashingService _hashingService;


    public UserManager(UserRepository userRepository, IMapper mapper , IMailService mailService , IHashingService hashingService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _mailService = mailService;
        _hashingService = hashingService;

    }


    public async Task<IEnumerable<UserGetDto>> GetList()
    {
        var users = await _userRepository.GetItems();

        return _mapper.Map<IEnumerable<UserGetDto>>(users);
    }

    public async Task<UserGetDto> GetItem(int id)
    {
        var user = await _userRepository.GetItem(id);

        return _mapper.Map<UserGetDto>(user);
    }

    public async Task<User> PostItem(UserCreateDto userCreateDto)
    {
        var existingUser = await _userRepository.GetItemsAsQueryable()
            .FirstOrDefaultAsync(u => u.Email == userCreateDto.Email);
    
        if (existingUser != null)
        {
            throw new Exception("A user with this email already exists.");
        }

        
        var user = _mapper.Map<User>(userCreateDto);

        user.Password = _hashingService.HashPassword(user.Password);
        
        await _userRepository.Add(user);

        foreach (var roleId in userCreateDto.RoleIds)
        {
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = roleId,
                CreatedBy = "Admin",
                UpdatedBy = "Admin",
                Deleted = false
            };
            await _userRepository.AddUserRole(userRole);
        }

        await _mailService.SendEmailAsync("test@gmail.com", "Yeni Kullanıcı Eklendi",
            user.Id + " Numaralı kullanıcı eklendi");

        return _mapper.Map<User>(user);
    }

    public async Task<bool> PutItem(int id, UserUpdateDto userUpdateDto)
    {
        var existingUser = await _userRepository.GetItem(id);

        if (existingUser == null)
        {
            return false;
        }

        _mapper.Map(userUpdateDto, existingUser);
        existingUser.Password = _hashingService.HashPassword(existingUser.Password); 
        
        await _userRepository.Update(existingUser);

        await _mailService.SendEmailAsync("test@gmail.com", "Kullanıcı Güncellendi",
            existingUser.Id + " Numaralı kullanıcınız güncellenmiştir.");
        
        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingUser = await _userRepository.Find(id);

        if (existingUser == null)
        {
            return false;
        }

        await _userRepository.Delete(existingUser);

        await _mailService.SendEmailAsync("test@gmail.com", "Kullanıcı Silindi",
            id + " Numaralı kullanıcınız silindi.");

        return true;
    }
    
    public async Task<UserGetDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetItemsAsQueryable()
            .Include(u => u.Roles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
        
        if (user == null)
        {
            Console.WriteLine($"No user found with email: {email}");
        }
        else
        {
            Console.WriteLine($"User found: {user.Email}, Roles count: {user.Roles.Count}");
            foreach (var role in user.Roles)
            {
                Console.WriteLine($"Role: {role.Role.RoleName}");
            }
        }
        return _mapper.Map<UserGetDto>(user);
    }

}

   
