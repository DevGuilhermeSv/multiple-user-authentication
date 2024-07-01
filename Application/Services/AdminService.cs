using Application.DTO;
using Application.DTO.Admin;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class AdminService: IAdminService
{
    public ServiceResult<Admin> CreateAdmin(AdminDto managerDto)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<Admin> GetAdminById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<IList<Admin>> GetAdmin()
    {
        throw new NotImplementedException();
    }
}