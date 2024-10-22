using Core.Domain.Extensions;
using DataAccess.EntityConfigurations;
using Domain.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class TenderAutoAppContext : DbContext
{
    public TenderAutoAppContext(DbContextOptions<TenderAutoAppContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenderConfiguration).Assembly);
        modelBuilder.AddGlobalFilter();

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleName = "Admin" },
            new Role { Id = 2, RoleName = "CompanyUser" },
            new Role { Id = 3, RoleName = "TenderResponsible" },
            new Role { Id = 4, RoleName = "User" }
        );


    }


    public DbSet<Company> Companies { get; set; }
    public DbSet<Tender> Tenders { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<CompanyTender> CompanyTenders { get; set; }
    public DbSet<TenderProduct> TenderProducts { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TenderProductList> TenderProductLists { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Permission> Permissions { get; set; }

    public DbSet<RolePermission> RolePermissions { get; set; }

    public DbSet<UserTender> UserTenders { get; set; }

    public DbSet<UserCompany> UserCompanies { get; set; }
}
