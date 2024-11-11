using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/HomeAdre/[controller]")]
    public class HomeAdreConroller : ControllerBase
    {
        private readonly IHomeAdreRepository _repository;
        public HomeAdreConroller(IHomeAdreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var HomeAdreList = await _repository.GetAllAsync();
            return Ok(HomeAdreList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHomeAdreById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHomeAdre(HomeAdre HomeAdre)
        {
            var createResult = await _repository.CreateHomeAdreAsync(HomeAdre);

            return CreatedAtAction(nameof(CreateHomeAdre), new { HomeAdre });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHomeAdre([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteHomeAdreAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHomeAdre(int id, HomeAdre HomeAdre)
        {
            var updatedHomeAdre = await
    _repository.UpdateHomeAdreAsync(id, HomeAdre);

            if (updatedHomeAdre == null)
            {
                return NotFound();
            }
            return Ok(updatedHomeAdre);
        }
    }
}
