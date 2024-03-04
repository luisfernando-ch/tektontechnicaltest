using Moq;
using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Entities;
using ProductsManagement.ApplicationCore.Product.Queries;
using ProductsManagement.ApplicationCore.Product.QueryHandlers;
using System.Linq.Expressions;

namespace ProductsManagement.Tdd.Implementation.Queries
{
    [TestFixture]
    public class GetProductByIdHandlerTests
    {
        private Mock<IProductRepository<Product>> _mockRepository;
        private GetProductByIdHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IProductRepository<Product>>();
            _handler = new GetProductByIdHandler(_mockRepository.Object);
        }

        [Test]
        public async Task Handle_ProductExists_ShouldReturnProduct()
        {
            //Arrange
            var productId = 1;
            _mockRepository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(new Product { ProductId = productId });
            
            //Agrega el Act
            var result = await _handler.Handle(new GetProductById { ProductId = productId });
            
            
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
