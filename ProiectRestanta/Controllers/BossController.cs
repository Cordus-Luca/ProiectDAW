using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectRestanta.Entities.DTOs;
using ProiectRestanta.Entities;
using ProiectRestanta.Repositories.BossRepository;
using ProiectRestanta.Models.Entities.DTOs;


namespace ProiectRestanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BossController : ControllerBase
    {
        private readonly IBossRepository _repository;
        public BossController(IBossRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all-bosses")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetAllBosses()
        {
            var bosses = await _repository.GetAllWithShop();

            var bossesToReturn = new List<BossDTO>();

            foreach (var boss in bosses)
            {
                bossesToReturn.Add(new BossDTO(boss));
            }

            return Ok(bossesToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetBossById(int id)
        {
            var boss = await _repository.GetByIdAsync(id);

            return Ok(new BossDTO(boss));
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateBoss(int id, CreateBossDTO dto)
        {
            var boss = await _repository.GetByIdAsync(id);

            if (boss == null)
            {
                return BadRequest("Boss does not exist");
            }

            boss.Nume = dto.Nume;
            boss.Prenume = dto.Prenume;
            boss.Salariu = dto.Salariu;
            boss.Shop = new Shop();

            _repository.Update(boss);
            await _repository.SaveAsync();

            return Ok(new BossDTO(boss));
        }

        [HttpDelete("delete-bosses")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> DeleteBoss(int id)
        {
            var boss = await _repository.GetByIdAsync(id);

            if (boss == null)
            {
                return NotFound("Boss does not exist");
            }

            _repository.Delete(boss);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost("create-boss")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateBoss(CreateBossDTO dto)
        {
            Boss newBoss = new Boss();

            newBoss.Nume = dto.Nume;
            newBoss.Prenume = dto.Prenume;
            newBoss.Salariu = dto.Salariu;

            _repository.Create(newBoss);

            await _repository.SaveAsync();

            return Ok("Boss was created!");
        }

    }
}
