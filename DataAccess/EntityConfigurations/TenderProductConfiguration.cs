using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class TenderProductConfiguration: IEntityTypeConfiguration<TenderProduct>
{
    public void Configure(EntityTypeBuilder<TenderProduct> builder)
    {
        builder.HasKey(ui => new { IhaleId = ui.TenderId, UrunId = ui.ProductId });

        builder.HasOne(ui => ui.Tender)
            .WithMany(i => i.TenderProducts)
            .HasForeignKey(ui => ui.TenderId);

        builder.HasOne(ui => ui.Product)
            .WithMany(u => u.TenderProducts)
            .HasForeignKey(ui => ui.ProductId);

        
    }
}