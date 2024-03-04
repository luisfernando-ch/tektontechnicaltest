using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Product.Commands;

namespace ProductsManagement.ApplicationCore.Product.CommandHandlers
{
    public class CreateProductHandler
    {
        private readonly IProductRepository<Entities.Product> _productRepository;

        public CreateProductHandler(IProductRepository<Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Entities.Product> Handle(CreateProduct request)
        {
            var productExists = _productRepository.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (productExists != null)
            {
                throw new Exception("ProductId ya existe");
            }

            var product = new Entities.Product
            {
                ProductId = request.ProductId,
                Name = request.Name,
                Status = request.Status,
                Stock = request.Stock,
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                FinalPrice = request.Price * (100 - request.Discount) / 100
            };

            return await _productRepository.AddAsync(product);
        }

    }
}
