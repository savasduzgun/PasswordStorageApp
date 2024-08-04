using Microsoft.EntityFrameworkCore;
using PasswordStorageApp.Webapi.Models;

namespace PasswordStorageApp.Webapi.Persistence.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}
