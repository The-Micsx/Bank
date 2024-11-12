using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/User/[controller]")]
    public class UserConroller : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserConroller(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var UserList = await _repository.GetAllAsync();
            return Ok(UserList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User User)
        {
            var createResult = await _repository.CreateUserAsync(User);

            return CreatedAtAction(nameof(CreateUser), new { User });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteUserAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User User)
        {
            var updatedUser = await
    _repository.UpdateUserAsync(id, User);

            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}
