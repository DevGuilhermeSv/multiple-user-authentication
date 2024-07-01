using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface IManagerService
{
    ServiceResult<Manager> CreateManager(ManagerDto managerDto);
    ServiceResult<Manager> GetManagerById(Guid id);
    ServiceResult<IList<Manager>> GetManager();
    ServiceResult<Manager> UpdateManager(Guid id, ManagerUpdateModel updateModel);
}