using Application.DTO;
using Application.DTO.Client;
using Domain.Entities;

namespace Application.Interfaces;

public interface IClientService
{
    ServiceResult<Client> CreateClient(ClientDto managerDto);
    ServiceResult<Client> GetClientById(Guid id);
    ServiceResult<IList<Client>> GetClient();
   // ServiceResult<Client> UpdateManager(Guid id, ClientUpdateModel updateModel);
}