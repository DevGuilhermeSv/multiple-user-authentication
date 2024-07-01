using Application.DTO;
using Application.DTO.Client;
using Domain.Entities;

namespace Application.Interfaces;

public interface IClientService
{
    ServiceResult<Client> CreateManager(ClientDto managerDto);
    ServiceResult<Client> GetManagerById(Guid id);
    ServiceResult<IList<Client>> GetManager();
   // ServiceResult<Client> UpdateManager(Guid id, ClientUpdateModel updateModel);
}