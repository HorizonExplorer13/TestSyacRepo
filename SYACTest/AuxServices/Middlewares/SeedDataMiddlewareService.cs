using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.Entitys;

namespace SYACTest.AuxServices.Middlewares
{
    public class SeedDataMiddlewareService
    {
        public RequestDelegate Request { get; }
        public SeedDataMiddlewareService(RequestDelegate request)
        {
            Request = request;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider,IConfiguration configuration)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                
                await dbContext.Database.MigrateAsync();

                
                if (!dbContext.Products.Any())
                {
                    dbContext.Products.AddRange(
                        new Products { productId = 1, productname = "Preset Product 1", unitValue = 10.0m },
                        new Products { productId = 2, productname = "Preset Product 2", unitValue = 20.0m },
                        new Products { productId = 2, productname = "Preset Product 3", unitValue = 30.0m },
                        new Products { productId = 2, productname = "Preset Product 4", unitValue = 40.0m },
                        new Products { productId = 2, productname = "Preset Product 5", unitValue = 50.0m }
                    );
                    await dbContext.SaveChangesAsync();
                }
            }  
            await Request(context);
        }
    }
}
        

