using Application.DTO;
using Application.DTO.Manager;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ManagerService: IManagerService
{
    private readonly IUserService _userService;

    public ManagerService(IUserService userService)
    {
        _userService = userService;
    }

    public ServiceResult<Manager> CreateManager(ManagerDto managerDto)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<Manager> GetManagerById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<IList<Manager>> GetManager()
    {
        throw new NotImplementedException();
    }

}

