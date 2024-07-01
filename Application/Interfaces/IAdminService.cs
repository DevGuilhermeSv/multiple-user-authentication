using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAdminService
{
    ServiceResult<Admin> CreateManager(AdminDto managerDto);
    ServiceResult<Admin> GetManagerById(Guid id);
    ServiceResult<IList<Admin>> GetManager();
    ServiceResult<Admin> UpdateManager(Guid id, AdminUpdateModel updateModel);
}