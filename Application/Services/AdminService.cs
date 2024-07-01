using Application.DTO;
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

    public ServiceResult<Admin> UpdateManager(Guid id, AdminUpdateModel updateModel)
    {
        throw new NotImplementedException();
    }
}