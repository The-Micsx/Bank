using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/TransactionType/[controller]")]
    public class TransactionTypeConroller : ControllerBase
    {
        private readonly ITransactionTypeRepository _repository;
        public TransactionTypeConroller(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var TransactionTypeList = await _repository.GetAllAsync();
            return Ok(TransactionTypeList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionTypeById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionType(TransactionType TransactionType)
        {
            var createResult = await _repository.CreateTransactionTypeAsync(TransactionType);

            return CreatedAtAction(nameof(CreateTransactionType), new { TransactionType });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTransactionType([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteTransactionTypeAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTransactionType(int id, TransactionType TransactionType)
        {
            var updatedTransactionType = await
    _repository.UpdateTransactionTypeAsync(id, TransactionType);

            if (updatedTransactionType == null)
            {
                return NotFound();
            }
            return Ok(updatedTransactionType);
        }
    }
}
