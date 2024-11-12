using Bank.Interfaces;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("apu/UserRole/[controller]")]
    public class UserRoleConroller : ControllerBase
    {
        private readonly IUserRoleRepository _repository;
        public UserRoleConroller(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var UserRoleList = await _repository.GetAllAsync();
            return Ok(UserRoleList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRoleById(int id)
        {
            var getId = await _repository.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole(UserRole UserRole)
        {
            var createResult = await _repository.CreateUserRoleAsync(UserRole);

            return CreatedAtAction(nameof(CreateUserRole), new { UserRole });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserRole([FromRoute] int id)
        {
            var deletedResult = await _repository.DeleteUserRoleAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUserRole(int id, UserRole UserRole)
        {
            var updatedUserRole = await
    _repository.UpdateUserRoleAsync(id, UserRole);

            if (updatedUserRole == null)
            {
                return NotFound();
            }
            return Ok(updatedUserRole);
        }
    }
}
