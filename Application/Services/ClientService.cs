using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ClientService : IClientService
{
    public ServiceResult<Client> CreateManager(ClientDto managerDto)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<Client> GetManagerById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<IList<Client>> GetManager()
    {
        throw new NotImplementedException();
    }

    public ServiceResult<Client> UpdateManager(Guid id, ClientUpdateModel updateModel)
    {
        throw new NotImplementedException();
    }
}

