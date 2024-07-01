using Application.DTO;
using Application.DTO.Client;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ClientService : IClientService
{
    public ServiceResult<Client> CreateClient(ClientDto managerDto)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<Client> GetClientById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<IList<Client>> GetClient()
    {
        throw new NotImplementedException();
    }
}

