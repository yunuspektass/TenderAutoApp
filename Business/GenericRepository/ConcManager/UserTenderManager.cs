using AutoMapper;
using Business.DTOs.UserTender;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class UserTenderManager : IUserTenderService
{


    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IHashingService _hashingService;
    private readonly UserTenderRepository _userTenderRepository;

    public UserTenderManager( IMapper mapper, IMailService mailService,
        IHashingService hashingService, UserTenderRepository userTenderRepository)
    {
        _mapper = mapper;
        _mailService = mailService;
        _hashingService = hashingService;
        _userTenderRepository = userTenderRepository;
    }


    public async Task<IEnumerable<UserTenderGetDto>> GetList()
    {
        var userTenders = await _userTenderRepository.GetItems();

        return _mapper.Map<IEnumerable<UserTenderGetDto>>(userTenders);
    }

    public async Task<UserTenderGetDto> GetItem(int id)
    {
        var userTender = await _userTenderRepository.GetItem(id);
        return _mapper.Map<UserTenderGetDto>(userTender);
    }

    public async Task<UserTender> PostItem(UserTenderCreateDto userTenderCreateDto)
    {
            var existingUserTender = await _userTenderRepository.FindUserTender(userTenderCreateDto.UserId, userTenderCreateDto.TenderId);
            if (existingUserTender != null)
            {
                throw new Exception("Bu kullanıcı zaten bu ihaleden sorumlu.");
            }

            var userTender = _mapper.Map<UserTender>(userTenderCreateDto);

            await _userTenderRepository.Add(userTender);

            await _mailService.SendEmailAsync("test@gmail.com", "İhale Sorumluluğu Eklendi",
                $"Tender ID: {userTenderCreateDto.TenderId} numaralı ihaleden sorumlu olarak atanmış bulunmaktasınız.");

            return userTender;
    }

    public async Task<bool> PutItem(int id, UserTenderUpdateDto userTenderUpdateDto)
    {

        var existingUser = await _userTenderRepository.GetItem(id);

        if (existingUser == null)
        {
            return false;
        }

        _mapper.Map(userTenderUpdateDto, existingUser);

        await _userTenderRepository.Update(existingUser);


        await _mailService.SendEmailAsync("test@gmail.com", "İhale Sorumlusu Güncellendi",
            existingUser.Id + " Numaralı ihale sorumlunuz güncellenmiştir.");

        return true;

    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingUser = await _userTenderRepository.Find(id);

        if (existingUser == null)
        {
            return false;
        }

        await _userTenderRepository.Delete(existingUser);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Sorumlusu Silindi",
            id + " Numaralı ihale sorumlusu silindi.");

        return true;
    }

    public async Task<bool> DeleteUserTendersByUserId(int userId)
    {
        var userTenders = await _userTenderRepository.GetByUserId(userId);

        if (userTenders == null || !userTenders.Any())
        {
            return false;
        }

        await _userTenderRepository.DeleteRange(userTenders);

        await _mailService.SendEmailAsync("test@gmail.com", "İhale Sorumlulukları Silindi",
            userId + " Numaralı kullanıcının tüm ihale sorumlulukları silindi.");

        return true;
    }

}
