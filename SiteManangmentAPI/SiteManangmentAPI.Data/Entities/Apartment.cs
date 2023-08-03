
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiteManangmentAPI.Base.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManangmentAPI.Data.Entities;

[Table("Apartments", Schema = "dbo")]
public class Apartment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApartmentId { get; set; }
    public int OwnerUserID { get; set; } // Foreign Key to Users 
    public int TenantUserID { get; set; } // Foreign Key to Users 

    public string Block { get; set; }
    public ApartmentStatus Status { get; set; }
    public ApartmentType Type { get; set; } // e.g Studio,
    public int Floor { get; set; }
    public string ApartmentNumber { get; set; }

    public virtual User OwnerUser { get; set; }
    public virtual User TenantUser { get; set; }


    //If we look at the yearly, the apartment may have more than one billing.
    public virtual List<Billing> Bills { get; set; }
}

//Configuration
public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("Apartments", "dbo");

        builder.Property(a => a.ApartmentId).IsRequired(true).UseIdentityColumn();
        builder.Property(a => a.OwnerUserID).IsRequired();
        builder.Property(a => a.TenantUserID).IsRequired();
        builder.Property(a => a.Block).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Status).IsRequired();
        builder.Property(a => a.Type).IsRequired();       
        builder.Property(a => a.Floor).IsRequired();
        builder.Property(a => a.ApartmentNumber).IsRequired().HasMaxLength(10);
                 

        // index
        builder.HasIndex(a => a.ApartmentNumber).IsUnique();

        //relationships
        builder.HasOne(a => a.OwnerUser)
               .WithMany(u => u.OwnedApartments)
               .HasForeignKey(a => a.OwnerUserID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.TenantUser)
               .WithMany(u => u.TenantedApartments)
               .HasForeignKey(a => a.TenantUserID)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(a => a.Bills) 
               .WithOne(b => b.Apartment)
               .HasForeignKey(b => b.ApartmentID)
               .OnDelete(DeleteBehavior.Cascade);
    }
}





