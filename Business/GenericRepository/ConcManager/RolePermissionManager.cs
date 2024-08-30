using AutoMapper;
using Business.DTOs.RolePermission;
using Business.DTOs.Tender;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class RolePermissionManager: IRolePermissionService
{
    private readonly RolePermissionRepository _rolePermissionRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public RolePermissionManager(RolePermissionRepository rolePermissionRepository , IMapper mapper , IMailService mailService)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    
       
    public async Task<IEnumerable<RolePermissionGetDto>> GetList()
    {
        var rolepermissions = await _rolePermissionRepository.GetItems();
        var rolepermissionDtos = _mapper.Map<List<RolePermissionGetDto>>(rolepermissions);
        return rolepermissionDtos;
    }

    public async Task<RolePermissionGetDto> GetItem(int id)
    {
        var rolepermissions = await _rolePermissionRepository.GetItem(id);

        if (rolepermissions == null)
        {
            return null;
        }

        var rolepermissionsDto = _mapper.Map<RolePermissionGetDto>(rolepermissions);

        return rolepermissionsDto;
    }

  

    public async Task<RolePermissionCreateDto> PostItem(RolePermissionCreateDto rolePermissionCreateDto)
    {
        var rolePermission = _mapper.Map<RolePermission>(rolePermissionCreateDto);

        await _rolePermissionRepository.Add(rolePermission);

        var resultDto = _mapper.Map<RolePermissionCreateDto>(rolePermission);

        await _mailService.SendEmailAsync("test@gmail.com", "Rol Yetkisi Eklendi",
            rolePermissionCreateDto.PermissionId + " Numaralı rol yetkisi listenize eklenmiştir");

        return resultDto;
    }

    public async Task<bool> PutItem(int id, RolePermissionUpdateDto rolePermissionUpdateDto)
    {
        var existingRolePermission = await _rolePermissionRepository.GetItem(id);

        if (existingRolePermission == null)
        {
            return false;
        }

        _mapper.Map(rolePermissionUpdateDto, existingRolePermission); 

        await _rolePermissionRepository.Update(existingRolePermission);

        await _mailService.SendEmailAsync("test@gmail.com", "Rol Yetkisi Güncelleme",
            rolePermissionUpdateDto.PermissionId + " Numaralı rol yetkiniz listenizde güncellenmiştir.");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingRolePermission = await _rolePermissionRepository.Find(id);

        if (existingRolePermission == null)
        {
            return false;
        }

        await _rolePermissionRepository.Delete(existingRolePermission);

        await _mailService.SendEmailAsync("test@gmail.com", "Rol Yetkisi Silindi",
            id + " Numaralı rol yetkiniz listenizden silinmiştir");

        return true;
    }
}