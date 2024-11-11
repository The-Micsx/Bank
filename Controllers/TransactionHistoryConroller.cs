using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/TransactionHistory/[controller]")]
    public class TransactionHistoryConroller : ControllerBase
    {
        private readonly ITransactionHistoryRepository _repository;
        public TransactionHistoryConroller(ITransactionHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var TransactionHistoryList = await _repository.GetAllAsync();
            return Ok(TransactionHistoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionHistoryById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionHistory(TransactionHistory TransactionHistory)
        {
            var createResult = await _repository.CreateTransactionHistoryAsync(TransactionHistory);

            return CreatedAtAction(nameof(CreateTransactionHistory), new { TransactionHistory });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTransactionHistory([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteTransactionHistoryAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTransactionHistory(int id, TransactionHistory TransactionHistory)
        {
            var updatedTransactionHistory = await
    _repository.UpdateTransactionHistoryAsync(id, TransactionHistory);

            if (updatedTransactionHistory == null)
            {
                return NotFound();
            }
            return Ok(updatedTransactionHistory);
        }
    }
}
