using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiteManangmentAPI.Base.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManangmentAPI.Data.Entities;

[Table("Users", Schema = "dbo")]
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; } // Primary Key

    public string Username { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; } //enum

    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public string Email { get; set; }
    public string TCNo { get; set; } //11
    public string VehiclePlateNumber { get; set; }
   
    public bool IsActive { get; set; } //to Track User
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }

    public virtual List<Apartment> OwnedApartments { get; set; }
    public virtual List<Apartment> TenantedApartments { get; set; }
    public virtual List<Payment> Payments { get; set; }
    public virtual List<Message> SentMessages { get; set; }
    public virtual List<Message> ReceivedMessages { get; set; }
    public virtual List<Contact> Contacts { get; set; }

}

//Configuration
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "dbo");

        builder.Property(u => u.UserId).IsRequired(true).UseIdentityColumn();
        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.UserType).IsRequired();
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.TCNo).IsRequired().HasMaxLength(11);
        builder.Property(u => u.VehiclePlateNumber).IsRequired(false).HasMaxLength(20);

        //index
        builder.HasIndex(u => u.Username).IsUnique();

        //relationships
        builder.HasMany(u => u.OwnedApartments)
               .WithOne(a => a.OwnerUser)
               .HasForeignKey(a => a.OwnerUserID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.TenantedApartments)
               .WithOne(a => a.TenantUser)
               .HasForeignKey(a => a.TenantUserID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Payments) 
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserID)
               .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(u => u.SentMessages) 
               .WithOne(m => m.SenderUser)
               .HasForeignKey(m => m.SenderUserID) 
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.ReceivedMessages) 
               .WithOne(m => m.ReceiverUser) 
               .HasForeignKey(m => m.ReceiverUserID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Contacts) 
               .WithOne(c => c.User) 
               .HasForeignKey(c => c.UserID) 
               .OnDelete(DeleteBehavior.Cascade);
    }
}
