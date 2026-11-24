using AiTech.Business.Services.BannerServices;
using AiTech.DTO.BannerDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IBannerService bannerService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var banners = await bannerService.GetAllAsync();
            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await  bannerService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto bannerDto)
        {
            await bannerService.CreateAsync(bannerDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto bannerDto)
        {
            await bannerService.UpdateAsync(bannerDto);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await bannerService.DeleteAsync(id);
            return NoContent();
        }
        
        [HttpPatch("makeActive/{id}")]
        public async Task<IActionResult> MakeActive(int id)
        {
            await bannerService.MakeActiveAsync(id);
            return NoContent();
        }
        
        [HttpPatch("makeInactive/{id}")]
        public async Task<IActionResult> MakeInactive(int id)
        {
            await bannerService.MakeInactiveAsync(id);
            return NoContent();
        }
    }
    
}
