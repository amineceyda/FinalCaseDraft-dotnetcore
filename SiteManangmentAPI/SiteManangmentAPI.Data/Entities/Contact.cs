
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using SiteManangmentAPI.Base.BaseEntities;

namespace SiteManangmentAPI.Data.Entities;

[Table("Contacts", Schema = "dbo")]
public class Contact : BaseEntity
{
    public int UserID { get; set; } // Foreign Key to Users

    public string ContactName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }

    public virtual User User { get; set; }

}

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts", "dbo");

        // Set the primary key
        builder.Property(c => c.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(c => c.InsertTime).IsRequired(true);
        builder.Property(c => c.UserID).IsRequired(true);
        builder.Property(c => c.ContactName).IsRequired(true).HasMaxLength(100);
        builder.Property(c => c.ContactPhone).IsRequired().HasMaxLength(20);
        builder.Property(c => c.ContactEmail).IsRequired(true).HasMaxLength(100);

        //relationships
        builder.HasOne(c => c.User) 
               .WithMany(u => u.Contacts)
               .HasForeignKey(c => c.UserID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
