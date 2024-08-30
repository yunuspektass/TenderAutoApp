using Core.Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class TenderTypesEnumConfiguration : IEntityTypeConfiguration<Tender>
{
    public void Configure(EntityTypeBuilder<Tender> builder)
    {
        builder
            .Property(e => e.TenderType)
            .HasConversion( 
                v => v.ToString(),
                v => (TenderTypes)Enum.Parse(typeof(TenderTypes), v)); 
    }
}