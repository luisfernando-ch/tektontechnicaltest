using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Product.Queries;

namespace ProductsManagement.ApplicationCore.Product.QueryHandlers
{
    public class GetProductByIdHandler
    {
        private readonly IProductRepository<Entities.Product> _productRepository;

        public GetProductByIdHandler(IProductRepository<Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Entities.Product?> Handle(GetProductById request)
        {
            return await _productRepository.FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
        }
    }
}
