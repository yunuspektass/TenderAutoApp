using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasOne(t => t.Tender)
            .WithMany(i => i.Offers)
            .HasForeignKey(t => t.TenderId);

        builder.HasOne(t => t.Company)
            .WithMany(f => f.Offers)
            .HasForeignKey(t => t.CompanyId);
    }
}