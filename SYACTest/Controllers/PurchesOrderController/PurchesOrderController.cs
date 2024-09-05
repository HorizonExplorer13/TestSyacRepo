using Microsoft.AspNetCore.Mvc;
using SYACTest.AuxModels;
using SYACTest.DTOs.PurchesOrders;
using SYACTest.Services.PurchesOrderService;

namespace SYACTest.Controllers.PurchesOrderController
{
    [ApiController]
    [Route("Api/PurchesOrders")]
    public class PurchesOrderController : ControllerBase
    {
        public IPurchesOrderService PurchesOrderService { get; }
        public PurchesOrderController(IPurchesOrderService purchesOrderService)
        {
            PurchesOrderService = purchesOrderService;
        }

        
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreatePurchesOrder([FromBody] CreatePurchesOrderDTO createPurchesOrder)
        {
            var serviceResponse = await PurchesOrderService.CreatePurchesOrder(createPurchesOrder);
            switch (serviceResponse.statusCode)
            {
                case 200:
                    return Ok(serviceResponse);
                case 400:
                    return BadRequest(serviceResponse);
                default:
                    return BadRequest(serviceResponse);
            }
            return Ok(createPurchesOrder);
        }
    }
}
