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

        [HttpGet]
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
        public async Task<IShopRepository> GetShopById( int id)
        {
            var shop = await _repository.GetByIdAsync(id);

            return (IShopRepository)Ok(new ShopDTO(shop));
        }

        

        [HttpDelete]
        public async Task<IShopRepository> DeleteShop(int id)
        {
            var shop = await _repository.GetByIdAsync(id);

            if(shop == null)
            {
                return (IShopRepository)NotFound("Shop does not exist");
            }

            _repository.Delete(shop);

            await _repository.SaveAsync();

            return (IShopRepository)NoContent();
        }

        [HttpPost]
        public async Task<IShopRepository> CreateShop(CreateShopDTO dto)
        {
            Shop newShop = new Shop();
            
            newShop.Nume = dto.Nume;
            newShop.Stoc = dto.Stoc;

            _repository.Create(newShop);

            await _repository.SaveAsync();

            return (IShopRepository)Ok(new ShopDTO(newShop));
        }

        [HttpPut("{id}")]
        public async Task<IShopRepository> UpdateShop(int id, CreateShopDTO dto)
        {
            var shop = await _repository.GetByIdAsync(id);

            if(shop == null)
            {
                return (IShopRepository)BadRequest("Shop does not exist");
            }

            shop.Nume = dto.Nume;
            shop.Stoc = dto.Stoc;
            shop.BossId = dto.BossId;
            shop.Boss = new Boss();
            shop.Shirts = new List<Shirt>();

            return (IShopRepository)Ok(new ShopDTO(shop));
        }
    }
}
