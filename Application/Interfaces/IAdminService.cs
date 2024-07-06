using Application.DTO;
using Application.DTO.Admin;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAdminService
{
    Task<ServiceResult<Admin>> CreateAdmin(AdminDto managerDto);
    ServiceResult<Admin> GetAdminById(Guid id);
    ServiceResult<IList<Admin>> GetAdmin();
    //ServiceResult<Admin> UpdateManager(Guid id, AdminUpdateModel updateModel);
}