using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordStorageApp.Webapi.Models;
using PasswordStorageApp.Webapi.Persistence;
using System.Security.Principal;

namespace PasswordStorageApp.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var accounts = FakeDbContext.Accounts.ToList();
            return Ok(accounts);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var account = FakeDbContext.Accounts.FirstOrDefault(ac => ac.Id == id);

            if (account is null)

                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public IActionResult Create(Account newAccount)
        {


            if (newAccount is null || string.IsNullOrEmpty(newAccount.Username) || string.IsNullOrEmpty(newAccount.Password))
                return BadRequest();

            FakeDbContext.Accounts.Add(newAccount);

            

            return Ok(newAccount.Id);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("id is not valid. Please do not send empty guids for god sake!");
            var account = FakeDbContext.Accounts.FirstOrDefault(ac => ac.Id == id);

            if (account is null)

                return NotFound();

            FakeDbContext.Accounts.Remove(account);

            return NoContent();
        }

    }
}
