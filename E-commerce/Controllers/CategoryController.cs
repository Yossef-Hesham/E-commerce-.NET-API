using BLL.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;


        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var AllCate = await _categoryManager.GetCategoriesAsync();

            return AllCate;
        }
        [HttpGet("id")]
        public async Task<CategoryDto> GetById(int id)
        {
            return await _categoryManager.GetById(id);
        }


        [HttpDelete("id")]
        [Authorize(Roles = "Admin")]
        public async Task Delete(int id)
        {
            await _categoryManager.DeleteCategory(id);
        }
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task Create(CategoryDto cate)
        {
            await _categoryManager.CreateCategoryAsync(cate);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromQuery] string name)
        {
            var result = await _categoryManager.UpdateCategory(id, name);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
