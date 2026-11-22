using AiTech.Business.Services.ProjectServices;
using AiTech.DTO.ProjectDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await projectService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("WithCategories")]
        public async Task<IActionResult> GetAllWithCategories()
        {
            var values = await projectService.GetProjectsWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await projectService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            await projectService.CreateAsync(dto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto dto)
        {
            await projectService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await projectService.DeleteAsync(id);
            return NoContent();
        }
    }
}

