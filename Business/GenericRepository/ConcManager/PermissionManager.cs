using AutoMapper;
using Business.DTOs.Permission;
using Business.DTOs.Product;
using Business.DTOs.Urun;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcManager;

public class PermissionManager : IPermissionService
{
    private readonly PermissionRepository _permissionRepository;
    private readonly IMapper _autoMapper;
    private readonly IMailService _mailService;
    private readonly RoleRepository _roleRepository;
    private readonly RolePermissionRepository _rolePermissionRepository;
    private readonly TenderAutoAppContext _context;

    public PermissionManager(PermissionRepository permissionRepository, IMapper autoMapper, IMailService mailService , RoleRepository roleRepository , RolePermissionRepository rolePermissionRepository , TenderAutoAppContext context)
    {
        _autoMapper = autoMapper;
        _permissionRepository = permissionRepository;
        _mailService = mailService;
        _roleRepository = roleRepository;
        _rolePermissionRepository = rolePermissionRepository;
        _context = context;
    }
        
        
        
    public async Task<IEnumerable<PermissionGetDto>> GetList()
    {
        var permissions = await _permissionRepository.GetItems();
        var permissionDtos = _autoMapper.Map<IEnumerable<PermissionGetDto>>(permissions);
        return permissionDtos;
    }

    public async Task<PermissionGetDto> GetItem(int id)
    {
        var permission = await _permissionRepository.GetItem(id);

        if (permission == null)
        {
            return null;
        }

        var permissionDto = _autoMapper.Map<PermissionGetDto>(permission);

        return permissionDto;
    }

    public async Task<PermissionCreateDto> PostItem(PermissionCreateDto permissionCreateDto)
    {
        var permission = _autoMapper.Map<Permission>(permissionCreateDto);
 
         await _permissionRepository.Add(permission);

        permission.RolePermissions = new List<RolePermission>();

        foreach (var roleId in permissionCreateDto.RoleIDs)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);

            if (role != null)
            {
                permission.RolePermissions.Add(new RolePermission
                {
                    Role = role,
                    Permission = permission
                });
            }
        }
       
        var resultDto = _autoMapper.Map<PermissionCreateDto>(permission);

        await _mailService.SendEmailAsync("test@gmail.com", "Yetki Eklendi",
            permissionCreateDto.PermissionName + " İsimli yetki listenize eklenmiştir");

        return resultDto;
    }

    public async Task<bool> PutItem(int id, PermissionUpdateDto permissionUpdateDto)
    {
        var existingPermission = await _permissionRepository.GetItem(id);

        if (existingPermission == null)
        {
            return false;
        }

        _autoMapper.Map(permissionUpdateDto, existingPermission);

        try
        {
            await _permissionRepository.Update(existingPermission);
        }
        catch (Exception ex)
        {
            throw new Exception("Permission güncellenirken bir hata oluştu", ex);
        }

        await _mailService.SendEmailAsync("test@gmail.com", "Yetki Güncelleme",
            id + " Numaralı yetki listenizde güncellenmiştir.");

        return true;
    }
    
    
    public async Task<bool> DeleteItem(int id)
    {
        var existingProduct = await _permissionRepository.Find(id);

        if (existingProduct == null)
        {
            return false;
        }

        await _permissionRepository.Delete(existingProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "Yetki Silindi",
            id + " Numaralı yetki listenizden silinmiştir");

        return true;
    }
}