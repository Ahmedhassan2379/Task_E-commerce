using E_commerce.Application.Interfaces;
using E_commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using E_commerce.Application.Dtos;
using AutoMapper;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IBaseRepository<Product> productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<List<ProductDto>>> GetAll() 
        { 
            var products =await _productRepository.GetAll("Category");
            if (products != null)
            {
                    var mapProduct = _mapper.Map<List<ProductDto>>(products);
                return Ok(mapProduct);
            }
            else 
            {
                return BadRequest("SomeThing");
            } 
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById(int id) 
        {
            var product = await _productRepository.GetById(p=>p.Id == id,"Category");
            if (product != null)
                return Ok(product);
            else
            {
                return BadRequest("SomeThing");
            }
        }

        [HttpPost("GetByName")]
        public async Task<ActionResult<List<ProductDto>>> Find(string[] categoryName)
        {
            if(categoryName.Length > 0)
            {
                var finalProducts = new List<ProductDto>();
                foreach (var item in categoryName)
                {
                    var result = await _productRepository.Find(p => p.Category.Name == item, "Category");
                    var mapProduct = _mapper.Map<List<ProductDto>>(result);
                    finalProducts.AddRange(mapProduct);
                }
                    return Ok(finalProducts);
            }
           
            else
            {
                var result = await _productRepository.Find(null,"Category");
                var mapProduct = _mapper.Map<List<ProductDto>>(result);
                    return Ok(mapProduct);
            }
        }

        [HttpGet("GetPaginationProduct")]
        public async Task<ActionResult<List<ProductDto>>> GetPagination(int page , int pageSize)
        {

            var result = await _productRepository.FindPagination(page, pageSize, "Category");
            var mapProduct = _mapper.Map<List<ProductDto>>(result);
            if (result != null)
                return Ok(mapProduct.ToList());
            else
            {
                return BadRequest("SomeThing");
            }
        }
    }
}
