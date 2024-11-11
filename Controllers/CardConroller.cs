using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/Card/[controller]")]
    public class CardConroller : ControllerBase
    {
        private readonly ICardRepository _repository;
        public CardConroller(ICardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cardList = await _repository.GetAllAsync();
            return Ok(cardList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(Card card)
        {
            var createResult = await _repository.CreateCardAsync(card);

            return CreatedAtAction(nameof(CreateCard), new { card });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteCardAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCard(int id, Card card)
        {
            var updatedCard = await
    _repository.UpdateCardAsync(id, card);

            if (updatedCard == null)
            {
                return NotFound();
            }
            return Ok(updatedCard);
        }
    }
}
