﻿using Microsoft.EntityFrameworkCore;
using PasswordStorageApp.Webapi.Models;
using PasswordStorageApp.Webapi.Persistence.Configurations;

namespace PasswordStorageApp.Webapi.Persistence.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
