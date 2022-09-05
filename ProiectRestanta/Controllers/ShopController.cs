using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProiectRestanta.Entities;
using ProiectRestanta.Entities.DTOs;
using ProiectRestanta.Repositories.ShopRepository;

namespace ProiectRestanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _repository;
        public ShopController(IShopRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all-shops")]
        public async Task<IActionResult> GetAllShops()
        {
            var shops = await _repository.GetAllShopsWithStock();

            var shopsToReturn = new List<ShopDTO>();

            foreach ( var shop in shops)
            {
                shopsToReturn.Add(new ShopDTO(shop));
            }

            return Ok(shopsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopById( int id)
        {
            var shop = await _repository.GetByIdAsync(id);

            return Ok(new ShopDTO(shop));
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _repository.GetByIdAsync(id);

            if(shop == null)
            {
                return NotFound("Shop does not exist");
            }

            _repository.Delete(shop);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost("create-shop")]
        public async Task<IActionResult> CreateShop(CreateShopDTO dto)
        {
            Shop newShop = new Shop();
            
            newShop.Nume = dto.Nume;
            newShop.Stoc = dto.Stoc;
            newShop.BossId = dto.BossId;

            _repository.Create(newShop);

            await _repository.SaveAsync();

            return Ok(new ShopDTO(newShop));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(int id, CreateShopDTO dto)
        {
            var shop = await _repository.GetByIdAsync(id);

            if(shop == null)
            {
                return BadRequest("Shop does not exist");
            }

            shop.Nume = dto.Nume;
            shop.Stoc = dto.Stoc;
            shop.BossId = dto.BossId;
            shop.Boss = new Boss();
            shop.Shirts = new List<Shirt>();

            _repository.Update(shop);
            await _repository.SaveAsync();

            return Ok(new ShopDTO(shop));
        }
    }
}
