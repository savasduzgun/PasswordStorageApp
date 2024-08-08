using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordStorageApp.Webapi.Dtos;
using PasswordStorageApp.Webapi.Models;
using PasswordStorageApp.Webapi.Persistence;
using PasswordStorageApp.Webapi.Persistence.Contexts;
using System.Security.Principal;

namespace PasswordStorageApp.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var accounts = await _dbContext.Accounts.AsNoTracking().ToListAsync(cancellationToken);
            return Ok(accounts);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var account = await _dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(ac => ac.Id == id, cancellationToken);

            if (account is null)

                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateDto newAccount)
        {

            var account = newAccount.ToAccount();
            
            _dbContext.Accounts.Add(account);

            //return Ok(account.Id);
            return Ok(new { data = account.Id, message = "The account was added successfully!" });
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, AccountUpdateDto updateDto)
        {
            if (id!=updateDto.Id)
            {
                return BadRequest("The id in the URL does not match the id in the body");
            }

            var account = _dbContext.Accounts.FirstOrDefault(ac=>ac.Id==id);

            var updatedAccount = updateDto.ToAccount(account);

            var index = _dbContext.Accounts.FindIndex(ac => ac.Id == id);

            _dbContext.Accounts[index] = updatedAccount;

            return Ok(new { data = updatedAccount, message = "The account was updated successfully!" });
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("id is not valid. Please do not send empty guids for god sake!");
            var account = _dbContext.Accounts.FirstOrDefault(ac => ac.Id == id);

            if (account is null)

                return NotFound();

            _dbContext.Accounts.Remove(account);

            return NoContent();
        }

    }
}
