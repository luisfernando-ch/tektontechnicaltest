using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Contracts.Services;
using ProductsManagement.ApplicationCore.Product.CommandHandlers;
using ProductsManagement.ApplicationCore.Product.Commands;
using ProductsManagement.ApplicationCore.Product.Queries;
using ProductsManagement.ApplicationCore.Product.QueryHandlers;

namespace ProductsManagement.ApplicationCore.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository<Entities.Product> _productRepository;  
        public ProductService(IProductRepository<Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Entities.Product> CreateProduct(CreateProduct request)
        {
            CreateProductHandler createProductHandler = new CreateProductHandler(_productRepository);
            return await createProductHandler.Handle(request);
        }

        public async Task<Entities.Product> UpdateProduct(UpdateProduct request)
        {
            UpdateProductHandler updateProductHandler = new UpdateProductHandler(_productRepository);
            return await updateProductHandler.Handle(request);
        }

        public async Task<Entities.Product?> GetProductById(GetProductById request)
        {
            GetProductByIdHandler getProductByIdHandler = new GetProductByIdHandler(_productRepository);
            return await getProductByIdHandler.Handle(request);
        }
    }
}