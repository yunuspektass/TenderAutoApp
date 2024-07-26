using AutoMapper;
using Business.DTOs.Unit;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class UnitManager:IUnitService
{
     private readonly UnitRepository _unitRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public UnitManager(UnitRepository unitRepository , IMapper mapper , IMailService mailService)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    public async Task<IEnumerable<UnitGetDto>> GetList()
    {
        var units = await _unitRepository.GetItems();

        return _mapper.Map<IEnumerable<UnitGetDto>>(units);
    }

    public async  Task<UnitGetDto> GetItem(int id)
    {
        var unit = await _unitRepository.GetItem(id);

        return _mapper.Map<UnitGetDto>(unit);
    }

    public async Task<UnitCreateDto> PostItem(UnitCreateDto unitCreateDto)
    {
        var unit = _mapper.Map<Unit>(unitCreateDto);

        await _unitRepository.Add(unit);

        await _mailService.SendEmailAsync("test@gmail.com", "Yeni Birim Eklendi",
            unit.UnitName + " Adlı birim Lsitenize Eklendi");

        return _mapper.Map<UnitCreateDto>(unit);

    }

    public async Task<bool> PutItem(int id, UnitUpdateDto unitUpdateDto)
    {
        var existingUnit = await _unitRepository.GetItem(id);

        if (existingUnit == null)
        {
            return false;
        }

        _mapper.Map(unitUpdateDto, existingUnit);

        await _unitRepository.Update(existingUnit);

        await _mailService.SendEmailAsync("test@gmail.com", "Birim Güncellendi",
            unitUpdateDto.UnitName + " Adlı birim güncellendi");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingOffer = await _unitRepository.Find(id);

        if (existingOffer == null)
        {
            return false;
        }

        await _unitRepository.Delete(existingOffer);

        await _mailService.SendEmailAsync("test@gmail.com", " Teklif Silindi",
            id + " Numaralı teklif silindi.");

        return true;

    }
}