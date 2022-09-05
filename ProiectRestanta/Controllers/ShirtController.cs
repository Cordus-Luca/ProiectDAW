using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectRestanta.Entities;
using ProiectRestanta.Models.Entities.DTOs;
using ProiectRestanta.Repositories.ShirtRepository;

namespace ProiectRestanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtController : ControllerBase
    {
        private readonly IShirtRepository _repository;
        public ShirtController(IShirtRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all-shirts")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetAllShirts()
        {
            var shirts = await _repository.GetAllShirtsWithShop();

            var shirtsToReturn = new List<ShirtDTO>();

            foreach (var shirt in shirts)
            {
                shirtsToReturn.Add(new ShirtDTO(shirt));
            }

            return Ok(shirtsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShirtById(int id)
        {
            var shirt = await _repository.GetByIdAsync(id);

            return Ok(new ShirtDTO(shirt));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShirt(int id, CreateShirtDTO dto)
        {
            var shirt = await _repository.GetByIdAsync(id);

            if (shirt == null)
            {
                return BadRequest("Shirt does not exist");
            }

            shirt.Culoare = dto.Culoare;
            shirt.ShopId = dto.ShopId;

            _repository.Update(shirt);
            await _repository.SaveAsync();

            return Ok("Shirt was updated");
        }
        [HttpDelete("delete-shirts")]
        public async Task<IActionResult> DeleteShirt(int id)
        {
            var shirt = await _repository.GetByIdAsync(id);

            if (shirt == null)
            {
                return NotFound("Shirt does not exist");
            }

            _repository.Delete(shirt);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost("create-shirt")]
        public async Task<IActionResult> CreateShirt(CreateShirtDTO dto)
        {
            Shirt newShirt = new Shirt();

            newShirt.Culoare = dto.Culoare;
            newShirt.ShopId = dto.ShopId;

            _repository.Create(newShirt);

            await _repository.SaveAsync();

            return Ok("Shirt was created!");
        }
    }
}
