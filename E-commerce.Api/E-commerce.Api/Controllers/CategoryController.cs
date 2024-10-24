using E_commerce.Application.Interfaces;
using E_commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Category> _categorRepository;
        public CategoryController(IBaseRepository<Category> categorRepository)
        {
            _categorRepository = categorRepository;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories() 
        {
            var categories = await _categorRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategory(int id) 
        {
            var category = await _categorRepository.GetById(p=>p.Id == id);
            return Ok(category);
        }

    }
}
