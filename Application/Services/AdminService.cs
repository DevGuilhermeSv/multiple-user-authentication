using Application.DTO;
using Application.DTO.Admin;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class AdminService: IAdminService
{
    public ServiceResult<Admin> CreateManager(AdminDto managerDto)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<Admin> GetManagerById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<IList<Admin>> GetManager()
    {
        throw new NotImplementedException();
    }
    
}