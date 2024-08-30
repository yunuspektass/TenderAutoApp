using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CompanyTenderConfiguration : IEntityTypeConfiguration<CompanyTender>
{
    public void Configure(EntityTypeBuilder<CompanyTender> builder)
    {
        builder.HasOne(fi => fi.Company)
            .WithMany(f => f.CompanyTenders)
            .HasForeignKey(fi => fi.CompanyId);

        builder.HasOne(fi => fi.Tender)
            .WithMany(i => i.CompanyTenders)
            .HasForeignKey(fi => fi.TenderId);
        
    }
}