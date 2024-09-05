using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;
using SYACTest.Services.Clients;

namespace SYACTest.Controllers.Clients
{
    [ApiController]
    [Route("Api/Clients")]
    public class ClientsControllers : ControllerBase
    {
        public ClientsControllers(AppDBContext dBContext,IClientsService clientsService)
        {
            DBContext = dBContext;
            ClientsService = clientsService;
        }

        public AppDBContext DBContext { get; }
        public IClientsService ClientsService { get; }

        [HttpGet]
        [Route("GetClientsList")]
        public async Task<IActionResult> GetClientList()
        {
            var result = await DBContext.clients.ToListAsync();
            return Ok(result);

            //List<ClientsList> DefaultClients = new List<ClientsList>
            //{
            //    new ClientsList { document = "1099989871", name = "clienteuno", address = "calle1" },
            //    new ClientsList { document = "1099989872", name = "clientedos", address = "calle2" },
            //    new ClientsList { document = "1099989873", name = "clientetres", address = "calle1" },
            //    new ClientsList { document = "1099989874", name = "clientecuatro", address = "calle3" },
            //    new ClientsList { document = "1099989875", name = "clientecinco", address = "calle5" },
            //};
            //return Ok(DefaultClients);
        }

        [HttpPost]
        [Route("CreateClient")]
        public async Task<IActionResult> createclient([FromBody] CreateClientDTO createClient)
        {
            var ServiceResponse = await ClientsService.createClients(createClient);
            switch (ServiceResponse.statusCode)
            {
                case 200:
                    return Ok(ServiceResponse);
                case 400:
                    return BadRequest(ServiceResponse);
                default:
                    return BadRequest(ServiceResponse);
            }
        }
    }
}
