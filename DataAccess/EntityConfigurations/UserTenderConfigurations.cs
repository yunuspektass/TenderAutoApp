using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserTenderConfigurations : IEntityTypeConfiguration<UserTender>
{

  public void Configure(EntityTypeBuilder<UserTender> builder)
  {

    builder.HasKey(ut => new { ut.UserId, ut.TenderId });


    builder.HasOne(ut => ut.User)
      .WithMany(u => u.UserTenders)
      .HasForeignKey(ut => ut.UserId);


    builder.HasOne(ut => ut.Tender)
      .WithMany(t => t.UserTenders)
      .HasForeignKey(ut => ut.TenderId);
  }
}

