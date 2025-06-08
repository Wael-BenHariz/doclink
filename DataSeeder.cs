using System;
using DocLink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAdminUserAsync(UserDbContext context)
        {
            if (!await context.Users.AnyAsync(u => u.Role == UserRole.Admin))
            {
                var passwordHasher = new PasswordHasher<User>();

                var adminUser = new User
                {
                    Username = "admin",
                    Email = "admin@doclink.com",
                    Role = UserRole.Admin,
                    FirstName = "System",
                    LastName = "Administrator",
                    PhoneNumber = "0000000000",
                    IsProfileComplete = true,
                };

                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123"); 
                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
