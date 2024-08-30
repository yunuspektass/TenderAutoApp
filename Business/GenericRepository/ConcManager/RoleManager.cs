using AutoMapper;
using Business.DTOs.Role;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class RoleManager: IRoleService
{
    private readonly RoleRepository _roleRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public RoleManager(RoleRepository roleRepository , IMapper mapper , IMailService mailService)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
        _mailService = mailService;
    }



    public async Task<IEnumerable<RoleGetDto>> GetList()
    {
        var roles = await _roleRepository.GetItems();
        var roleDtos = _mapper.Map<List<RoleGetDto>>(roles);
        return roleDtos;
    }

    public async Task<RoleGetDto> GetItem(int id)
    {
        var role = await _roleRepository.GetItem(id);

        if (role == null)
        {
            return null;
        }

        var roleDto = _mapper.Map<RoleGetDto>(role);

        return roleDto;
    }

    public async Task<RoleCreateDto> PostItem(RoleCreateDto roleCreateDto)
    {
        var role = _mapper.Map<Role>(roleCreateDto);

        await _roleRepository.Add(role);

        var resultDto = _mapper.Map<RoleCreateDto>(role);

        await _mailService.SendEmailAsync("test@gmail.com", "Rol Eklendi",
            roleCreateDto.RoleName + " İsimli rol listenize eklenmiştir");

        return resultDto;
    }

    public async Task<bool> PutItem(int id, RoleUpdateDto roleUpdateDto)
    {
        var existingRole = await _roleRepository.GetItem(id);

        if (existingRole == null)
        {
            return false;
        }

        _mapper.Map(roleUpdateDto, existingRole);

        await _roleRepository.Update(existingRole);

        await _mailService.SendEmailAsync("test@gmail.com", "Rol Güncelleme",
            roleUpdateDto.Id + " Numaralı rol listenizde güncellenmiştir.");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingProduct = await _roleRepository.Find(id);

        if (existingProduct == null)
        {
            return false;
        }

        await _roleRepository.Delete(existingProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "Rol Silindi",
            id + " Numaralı rol listenizden silinmiştir");

        return true;
    }

}
