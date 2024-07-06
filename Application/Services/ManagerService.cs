using Application.DTO;
using Application.DTO.Manager;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Interfaces;

namespace Application.Services;

public class ManagerService: IManagerService
{
    private readonly IUserService _userService;
    private readonly IManagerRepository _managerRepository; 
    public ManagerService(IUserService userService, IManagerRepository managerRepository)
    {
        _userService = userService;
        _managerRepository = managerRepository;
    }


    public async Task<ServiceResult<Manager>> CreateManager(ManagerDto managerDto)
    {
        var userResult = await _userService.UserRegister(managerDto.RegisterUserDto);
        if (!userResult.Success)
            return ServiceResult<Manager>.FailResult("Fail at register user");
        await _userService.RegisterRole(userResult.Data!.Email!, Roles.Admin);

        var manager = new Manager()
        {
            UserId = userResult.Data.Id
        };
        _managerRepository.Add(manager);
        return ServiceResult<Manager>.SucessResult(manager,"User Registered with success");
    }

    public ServiceResult<Manager> GetManagerById(Guid id)
    {
        var result = _managerRepository.GetById(id);
        return result is not null? ServiceResult<Manager>.SucessResult( result,null) : ServiceResult<Manager>.FailResult("User not found");

    }

    public ServiceResult<IList<Manager>> GetManager()
    {
        var result = _managerRepository.GetAll().ToList();
        return result.Any()? ServiceResult<IList<Manager>>.SucessResult( result.ToList(),null) : ServiceResult<IList<Manager>>.FailResult("User not found");

    }

}

