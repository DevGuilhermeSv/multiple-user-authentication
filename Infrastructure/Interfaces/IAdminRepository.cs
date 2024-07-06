using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IAdminRepository: IBaseRepository<Admin>
    {
        IQueryable<Admin> GetAll();
    }
}
