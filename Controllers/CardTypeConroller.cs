using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/CardType/[controller]")]
    public class CardTypeConroller : ControllerBase
    {
        private readonly ICardTypeRepository _repository;
        public CardTypeConroller(ICardTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cardTypeList = await _repository.GetAllAsync();
            return Ok(cardTypeList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardTypeById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardType(CardType cardType)
        {
            var createResult = await _repository.CreateCardTypeAsync(cardType);

            return CreatedAtAction(nameof(CreateCardType), new { cardType });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCardType([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteCardTypeAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCardType(int id, CardType cardType)
        {
            var updatedCardType = await
    _repository.UpdateCardTypeAsync(id, cardType);

            if (updatedCardType == null)
            {
                return NotFound();
            }
            return Ok(updatedCardType);
        }
    }
}
