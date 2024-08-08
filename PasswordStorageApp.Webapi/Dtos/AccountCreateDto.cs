﻿using PasswordStorageApp.Webapi.Enums;
using PasswordStorageApp.Webapi.Models;
using System.ComponentModel.DataAnnotations;

namespace PasswordStorageApp.Webapi.Dtos
{
    public class AccountCreateDto
    {
        [Required, MinLength(6),MaxLength(40)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(40)]
        public string Password { get; set; }

        [Required, AllowedValues(AccountType.Web, AccountType.Mobile, AccountType.Desktop)]
        public AccountType Type { get; set; }

        public Account ToAccount()
        {
            return new Account
            {
                Id = Ulid.NewUlid().ToGuid(),
                Username = Username,
                Password = Password,
                Type = Type,
                CreatedOn = DateTimeOffset.UtcNow

            };
            
        }
    }
}
