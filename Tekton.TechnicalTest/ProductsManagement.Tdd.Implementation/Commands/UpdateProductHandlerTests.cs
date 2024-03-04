using Moq;
using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.ApplicationCore.Entities;
using ProductsManagement.ApplicationCore.Product.CommandHandlers;
using ProductsManagement.ApplicationCore.Product.Commands;
using System.Linq.Expressions;

namespace ProductsManagement.Tdd.Implementation.Commands
{
    [TestFixture]
    public class UpdateProductHandlerTests
    {
        private Mock<IProductRepository<Product>> _mockRepository;
        private UpdateProductHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IProductRepository<Product>>();
            _handler = new UpdateProductHandler(_mockRepository.Object);
        }

        [Test]
        public async Task Handle_ProductExists_ShouldUpdateProduct()
        {
            //Arrange
            var request = new UpdateProduct
            {
                ProductId = 1,
                Name = "Product 1",
                Status = 1,
                Stock = 100,
                Description = "Description1",
                Price = 100,
                Discount = 10
            };
            _mockRepository.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).Returns(new Product());
            _mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(new Product());

            //Act
            var result = await _handler.Handle(request);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
