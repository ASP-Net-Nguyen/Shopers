using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopers.Models;
using Shopers.Models.Product;
using Shopers.Service.CategoryService;

namespace Shopers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("category")]
        public IActionResult Get()
        {
            var result = categoryService.GetAllCategory();
            return Ok(result);
        }
        [HttpGet("category/{id}")]
        public IActionResult GetId(int id)
        {
            var result = categoryService.GetCategoryById(id);
            return Ok(result);
        }
        [HttpPost("createcategory")]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về thông báo lỗi validation nếu có
            }
            /*           category.Products = null;*/
            var createdCategory = await categoryService.CreateCategory(category);
            return Ok(createdCategory);
        }
        [HttpPost("updatecategory/{id}")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về thông báo lỗi validation nếu có
            }
            /*category.Products = null;*/
            var createdCategory = await categoryService.UpdateCategory(category);
            return Ok(createdCategory);
        }
        [HttpDelete("category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            categoryService.GetCategoryById(id);
            return BadRequest();
        }
    }
}
