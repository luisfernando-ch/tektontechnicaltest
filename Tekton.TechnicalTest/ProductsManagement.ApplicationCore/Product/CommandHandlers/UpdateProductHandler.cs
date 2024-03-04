using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Product.Commands;

namespace ProductsManagement.ApplicationCore.Product.CommandHandlers
{
    public class UpdateProductHandler
    {
        private readonly IProductRepository<Entities.Product> _productRepository;

        public UpdateProductHandler(IProductRepository<Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Entities.Product> Handle(UpdateProduct request)
        {
            var product = _productRepository.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }

            product.Name = request.Name;
            product.Status = request.Status;
            product.Stock = request.Stock;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Discount = request.Discount;
            product.FinalPrice = request.Price * (100 - request.Discount) / 100;

            return await _productRepository.UpdateAsync(product);
        }

    }
}
