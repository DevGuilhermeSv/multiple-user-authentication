using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public class AdminRepository: BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Admin> GetAll()
        {
            return DbSet;
        }
    }
}
