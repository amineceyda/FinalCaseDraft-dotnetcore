using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiteManangmentAPI.Base.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using SiteManangmentAPI.Base.BaseEntities;


namespace SiteManangmentAPI.Data.Entities
{
    [Table("Users", Schema = "dbo")]
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TCNo { get; set; }
        public string VehiclePlateNumber { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual List<Apartment> OwnedApartments { get; set; }
        public virtual List<Apartment> TenantedApartments { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual List<Message> SentMessages { get; set; }
        public virtual List<Message> ReceivedMessages { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }

    // Configuration
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.Property(u => u.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(u => u.InsertTime).IsRequired(true);
            builder.Property(u => u.Username).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.UserType).IsRequired(true);
            builder.Property(u => u.FirstName).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.TCNo).IsRequired(true).HasMaxLength(11);
            builder.Property(u => u.VehiclePlateNumber).IsRequired(false).HasMaxLength(20);
            builder.Property(u => u.IsActive).IsRequired();

            builder.HasIndex(u => u.Username).IsUnique();

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
}
