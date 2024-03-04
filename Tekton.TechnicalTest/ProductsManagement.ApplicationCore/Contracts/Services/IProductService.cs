using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductsManagement.ApplicationCore.Product.Commands;
using ProductsManagement.ApplicationCore.Product.Queries;

namespace ProductsManagement.ApplicationCore.Contracts.Services
{
    public interface IProductService
    {
        Task<Entities.Product> CreateProduct(CreateProduct request);
        Task<Entities.Product> UpdateProduct(UpdateProduct request);
        Task<Entities.Product?> GetProductById(GetProductById request);
    }
}
