using AiTech.Business.Services.CategoryServices;
using AiTech.DTO.CategoryDtos;
using AiTech.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await  categoryService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            await categoryService.CreateAsync(categoryDto);
            return Ok("Kategori Oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            await categoryService.UpdateAsync(categoryDto);
            return Ok("Kategori başarıyla güncellendi.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.DeleteAsync(id);
            return Ok("Kategori silindi.");
        }
        
    }
}
