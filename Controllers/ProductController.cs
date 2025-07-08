using DsiCode.Micro.Product.API.Models.Dto;
using DsiCode.Micro.Product.API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DsiCode.Micro.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseDto> GetAll()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ResponseDto> Post([FromForm] ProductDto productDto)
        {
            return await _productService.CreateProductAsync(productDto);
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ResponseDto> Put([FromForm] ProductDto productDto)
        {
            return await _productService.UpdateProductAsync(productDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ResponseDto> Delete(int id)
        {
            return await _productService.DeleteProductAsync(id);
        }
    }
}