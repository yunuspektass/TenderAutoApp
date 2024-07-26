using AutoMapper;
using Business.DTOs.TenderStatus;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class TenderStatusManager:ITenderStatusService
{
     private readonly TenderStatusRepository _tenderStatusRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public TenderStatusManager(TenderStatusRepository tenderStatusRepository, IMapper mapper , IMailService mailService)
    {
        _tenderStatusRepository = tenderStatusRepository;
        _mapper = mapper;
        _mailService = mailService;
    }


    public async Task<IEnumerable<TenderStatusGetDto>> GetList()
    {
        var tenderStatuses = await _tenderStatusRepository.GetItems();

        return _mapper.Map<IEnumerable<TenderStatusGetDto>>(tenderStatuses);
    }

    public async Task<TenderStatusGetDto> GetItem(int id)
    {
        var tenderStatus = await _tenderStatusRepository.GetItem(id);

        return _mapper.Map<TenderStatusGetDto>(tenderStatus);
    }

    public async Task<TenderStatusCreateDto> PostItem(TenderStatusCreateDto tenderStatusCreateDto)
    {
        var tenderStatus = _mapper.Map<TenderStatus>(tenderStatusCreateDto);

        await _tenderStatusRepository.Add(tenderStatus);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Durumu Eklendi",
            tenderStatus.Description + " Açıklamalı ihale durumu eklendi");

        return _mapper.Map<TenderStatusCreateDto>(tenderStatus);
    }

    public async Task<bool> PutItem(int id, TenderStatusUpdateDto tenderStatusUpdateDto)
    {
        var existingTenderStatus = await _tenderStatusRepository.GetItem(id);

        if (existingTenderStatus == null)
        {
            return false;
        }

        _mapper.Map(tenderStatusUpdateDto, existingTenderStatus);

        await _tenderStatusRepository.Update(existingTenderStatus);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Durumu Güncellendi",
            tenderStatusUpdateDto.Id + " Numaralı ihale durumunuz güncellenmiştir.");
        
        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingTenderResponsible = await _tenderStatusRepository.Find(id);

        if (existingTenderResponsible == null)
        {
            return false;
        }

        await _tenderStatusRepository.Delete(existingTenderResponsible);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Sorumlusu Silindi",
            id + " Numaralı ihale sorumlunuz silindi.");

        return true;
    }
}