using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Api.DataTransferObjects;
using ProductsManagement.ApplicationCore.Contracts.Services;
using ProductsManagement.ApplicationCore.Product.Commands;
using ProductsManagement.ApplicationCore.Product.Queries;

namespace ProductsManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService? _productService;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, IProductService service, IMapper mapper)
        {
            _logger = logger;
            _productService = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(new GetProductById { ProductId = id });
            
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct request)
        {
            request.Discount = GetDiscountValue(request.ProductId);
            var product = await _productService.CreateProduct(request);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProduct request)
        {
            if (id != request.ProductId)
            {
                return BadRequest();
            }
            request.Discount = GetDiscountValue(request.ProductId);
            var product = await _productService.UpdateProduct(request);
            return Ok(product);
        }


        #region External Services Adapters
        private byte GetDiscountValue(int productId)
        {
            return new ExternalServicesAdapters.DiscountAdapter().GetDiscountValue(productId);
        }

        private string GetStatusProduct(int status)
        {
            return new ExternalServicesAdapters.StatusAdapter().GetStatusProduct(status);
        }
        #endregion
    }
}
