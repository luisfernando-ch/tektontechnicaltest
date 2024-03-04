using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Contracts.Services;
using ProductsManagement.ApplicationCore.Services;
using ProductsManagement.Infrastructure.Repositories;
using ProductsManagement.ApplicationCore;
using ProductsManagement.Persistence.SqlServer.Contexts;
using ProductsManagement.Api.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductsDatabaseContext>();
builder.Services.AddScoped<IProductRepository<ProductsManagement.ApplicationCore.Entities.Product>, ProductRepository<ProductsManagement.ApplicationCore.Entities.Product>>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
