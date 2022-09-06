using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectRestanta.Entities;
using ProiectRestanta.Models.Entities.DTOs;
using ProiectRestanta.Repositories.DesignRepository;
using System.Data;

namespace ProiectRestanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        private readonly IDesignRepository _repository;
        public DesignController(IDesignRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public async Task<IActionResult> GetDesignById(int id)
        {
            var design = await _repository.GetByIdAsync(id);

            return Ok(new DesignDTO(design));
        }

        [HttpPut("get-designs-by-id")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public async Task<IActionResult> UpdateDesign(int id, CreateDesignDTO dto)
        {
            var design = await _repository.GetByIdAsync(id);

            if (design == null)
            {
                return BadRequest("Design does not exist");
            }

            design.Model = dto.Model;
            design.Culoare = dto.Culoare;
            design.Pret = dto.Pret;

            _repository.Update(design);
            await _repository.SaveAsync();

            return Ok(new DesignDTO(design));
        }

        [HttpDelete("delete-designs")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> DeleteDesign(int id)
        {
            var design = await _repository.GetByIdAsync(id);

            if (design == null)
            {
                return NotFound("Design does not exist");
            }

            _repository.Delete(design);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost("create-design")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateDesign(CreateDesignDTO dto)
        {
            Design newDesign = new Design();

            newDesign.Model = dto.Model;
            newDesign.Culoare = dto.Culoare;
            newDesign.Pret = dto.Pret;

            _repository.Create(newDesign);

            await _repository.SaveAsync();

            return Ok("Design was created!");
        }
    }
}
