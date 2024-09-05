using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.Clients
{
    public class ClientsService : IClientsService
    {
        public ClientsService(AppDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public AppDBContext DBContext { get; }

        public async Task<ServiceResponse<ClientsEntity>> createClients(CreateClientDTO createClient)
        {
            var create = new ClientsEntity { 
                clientName = createClient.name,
                clientAddress = createClient.address,
                clientDocument = createClient.document,
            };

            DBContext.clients.Add(create);
            var result = await DBContext.SaveChangesAsync();
            return new ServiceResponse<ClientsEntity> {
                statusCode = 200,
            };
        }
    }
}
