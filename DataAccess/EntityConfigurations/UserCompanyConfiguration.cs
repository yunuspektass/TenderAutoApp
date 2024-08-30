using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserCompanyConfiguration: IEntityTypeConfiguration<UserCompany>
{

    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {

        builder.HasKey(ut => new { ut.UserId, ut.CompanyId });


        builder.HasOne(ut => ut.User)
            .WithMany(u => u.UserCompanies)
            .HasForeignKey(ut => ut.UserId);


        builder.HasOne(ut => ut.Company)
            .WithMany(t => t.UserCompanies)
            .HasForeignKey(ut => ut.CompanyId);
    }

}
