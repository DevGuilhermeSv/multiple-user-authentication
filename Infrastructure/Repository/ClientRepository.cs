using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public class ClientRepository: BaseRepository<Client>
    {
        public ClientRepository(DbContext context) : base(context)
        {
        }
    }
}
