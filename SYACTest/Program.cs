using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.AuxServices.Middlewares;
using SYACTest.Services.Clients;
using SYACTest.Services.ProductsServices;
using SYACTest.Services.PurchesOrderService;

var builder = WebApplication.CreateBuilder(args);
var Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Connection));
builder.Services.AddControllers();
builder.Services.AddScoped<IPurchesOrderService, PurchesOrderService>();
builder.Services.AddScoped<IProductService, Productservices>();
builder.Services.AddScoped<IClientsService, ClientsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<SeedDataMiddlewareService>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
