using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/ExchangeRate/[controller]")]
    public class ExchangeRateConroller : ControllerBase
    {
        private readonly IExchangeRateRepository _repository;
        public ExchangeRateConroller(IExchangeRateRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ExchangeRateList = await _repository.GetAllAsync();
            return Ok(ExchangeRateList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExchangeRateById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExchangeRate(ExchangeRate ExchangeRate)
        {
            var createResult = await _repository.CreateExchangeRateAsync(ExchangeRate);

            return CreatedAtAction(nameof(CreateExchangeRate), new { ExchangeRate });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteExchangeRate([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteExchangeRateAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateExchangeRate(int id, ExchangeRate ExchangeRate)
        {
            var updatedExchangeRate = await
    _repository.UpdateExchangeRateAsync(id, ExchangeRate);

            if (updatedExchangeRate == null)
            {
                return NotFound();
            }
            return Ok(updatedExchangeRate);
        }
    }
}
