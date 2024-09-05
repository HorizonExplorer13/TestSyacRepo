using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.Clients
{
    public interface IClientsService
    {
        Task<ServiceResponse<ClientsEntity>> createClients(CreateClientDTO createClient);
    }
}
