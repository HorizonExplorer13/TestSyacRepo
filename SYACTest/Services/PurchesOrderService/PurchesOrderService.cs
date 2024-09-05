using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using SYACTest.DTOs.PurchesOrders;
using SYACTest.Services.Clients;
using SYACTest.DTOs;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SYACTest.Services.PurchesOrderService
{
    public class PurchesOrderService : IPurchesOrderService
    {
        public AppDBContext DBContext { get; }
        public IClientsService ClientsService { get; }

        public PurchesOrderService(AppDBContext appDBContext,IClientsService clientsService)
        {
            DBContext = appDBContext;
            ClientsService = clientsService;
        }
       
        public async Task<ServiceResponse<List<PurchesOrderDTO>>> GetPurchesOrdersList()
        {
            var purchesOrders = await DBContext.purchesOrders.Include(cl => cl.client).Include(opr => opr.orderProducts).ThenInclude(pro => pro.products).ToListAsync();

            return new ServiceResponse<List<PurchesOrderDTO>>
            {
                statusCode = 200,
            };
        }

        public async Task<ServiceResponse<PurchesOrders>> CreatePurchesOrder(CreatePurchesOrderDTO createPurchesOrder)
        {
            var ExistedClient = await DBContext.clients.FirstOrDefaultAsync(cl => cl.clientDocument == createPurchesOrder.clientDocument);
            do
            {           
                if (ExistedClient == null)
                {
                    var createNewClient = new CreateClientDTO
                    {
                        document = createPurchesOrder.clientDocument,
                        name = createPurchesOrder.clientName,
                        address = createPurchesOrder.clientAddrees
                    };
                    await ClientsService.createClients(createNewClient);
                }
                ExistedClient = await DBContext.clients.FirstOrDefaultAsync(cl => cl.clientDocument == createPurchesOrder.clientDocument);
            } while (ExistedClient == null);      
            using var transaction = await DBContext.Database.BeginTransactionAsync();
            PurchesOrders createPartialPurchesOrder ;
            var totalProducts = await DBContext.Products.CountAsync();
            var totalUnitValuesSum = await DBContext.Products.SumAsync(p => p.unitValue);
            try
            {
                
                 createPartialPurchesOrder = new PurchesOrders
                {
                    clientId = ExistedClient.clientId,
                    deliveryAddress = createPurchesOrder.deliveryAddress,
                    recordDate = DateTime.UtcNow,
                    state = "pending",
                    priority = genPriority(createPurchesOrder.totalValue,totalProducts,totalUnitValuesSum),
                    totalValue = createPurchesOrder.totalValue
                };

                DBContext.purchesOrders.Add(createPartialPurchesOrder);
                await DBContext.SaveChangesAsync();
                var newOrderProductsList = new List<OrderProducts>();
                foreach(var item in createPartialPurchesOrder.orderProducts)
                {
                    var product = await DBContext.Products.FindAsync(item.productId);
                    var orderProduct = new OrderProducts
                    {
                        purchaseOrderId = item.purchaseOrderId,
                        productId = item.productId,
                        quantity = item.quantity,
                        partialValue = item.partialValue,
                    };
                    newOrderProductsList.Add(orderProduct);
                }
                DBContext.orderProducts.AddRange(newOrderProductsList);
                await DBContext.SaveChangesAsync();
                await transaction.CommitAsync();
                var completepurchesOrder = await DBContext.purchesOrders.Include(cl => cl.client).Include(opr => opr.orderProducts).ThenInclude(op => op.products).FirstOrDefaultAsync(cpo => cpo.purchesOrderid == createPartialPurchesOrder.purchesOrderid);
                return new ServiceResponse<PurchesOrders>
                {
                    statusCode = 200,
                    data = completepurchesOrder
                };
            } catch (Exception ex) {
                return new ServiceResponse<PurchesOrders> {
                    statusCode = 400,
                    messages = ex.ToString()
                };
            }
        }

        private static string genPriority(decimal value,int totalProducts, int totalUnitValuesSum)
        {
            var media = totalUnitValuesSum/totalProducts;
            if (value > 1 &&  value < media)
            {
                return "Low";
            }else if (value > media && value < totalUnitValuesSum)
            {
                return "Medium";
            }
            else
            {
                return "High";
            }
        }

    }
}
