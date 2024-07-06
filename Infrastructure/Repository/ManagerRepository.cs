using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public class ManagerRepository: BaseRepository<Manager>
    {
        public ManagerRepository(DbContext context) : base(context)
        {
        }
    }
}
