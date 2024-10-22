using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using (var context = new TenderAutoAppContext(
                   serviceProvider.GetRequiredService<DbContextOptions<TenderAutoAppContext>>()))
        {
            if (!await context.Roles.AnyAsync())
            {
                await context.Roles.AddRangeAsync(
                    new Role { Id = 1, RoleName = "Admin" },
                    new Role { Id = 2, RoleName = "CompanyUser" },
                    new Role { Id = 3, RoleName = "TenderResponsible" },
                    new Role { Id = 4, RoleName = "User" }
                );
                await context.SaveChangesAsync();
            }

            if (!await context.Users.AnyAsync(u => u.Email == "yunus@gmail.com"))
            {
                var adminUser = new User
                {
                    Name = "Yunus",
                    LastName = "Pektaş",
                    Email = "yunus@gmail.com",
                    PhoneNumber = "5555555555",
                    Address = "İstanbul"
                };

                adminUser.Password = BCrypt.Net.BCrypt.HashPassword("yunus");

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();

                await context.UserRoles.AddAsync(new UserRole { UserId = adminUser.Id, RoleId = 1 });
                await context.SaveChangesAsync();
            }
        }
    }
}
