using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public class AdminRepository: BaseRepository<Admin>
    {
        public AdminRepository(DbContext context) : base(context)
        {
        }
    }
}
