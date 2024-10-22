using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DataAccess.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TenderAutoAppContext(
                       serviceProvider.GetRequiredService<DbContextOptions<TenderAutoAppContext>>()))
            {

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { Id = 1, RoleName = "Admin" },
                        new Role { Id = 2, RoleName = "CompanyUser" },
                        new Role { Id = 3, RoleName = "TenderResponsible" },
                        new Role { Id = 4, RoleName = "User" }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any(u => u.Email == "yunus@gmail.com"))
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

                    context.Users.Add(adminUser);
                    context.SaveChanges();

                    context.UserRoles.Add(new UserRole { UserId = adminUser.Id, RoleId = 1 });
                    context.SaveChanges();
                }
            }
        }
    }
}
