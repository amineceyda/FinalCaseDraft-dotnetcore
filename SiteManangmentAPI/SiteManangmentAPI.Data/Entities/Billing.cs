
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManangmentAPI.Data.Entities;

[Table("Billing", Schema = "dbo")]
public class Billing
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BillingID { get; set; } // Primary Key
    public int ApartmentID { get; set; } // Foreign Key

    public DateTime BillingDate { get; set; }
    public decimal BillAmount { get; set; }
    public decimal RentAmount { get; set; }

    public virtual Apartment Apartment { get; set; }

    //An invoice can have one or more payments,
    //assuming the possibility of payment in parts
    public virtual List<Payment> Payments { get; set; }
}

//Configuration
public class BillingConfiguration : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> builder)
    {
        builder.ToTable("Billing", "dbo");

        builder.Property(b => b.BillingID).IsRequired(true).UseIdentityColumn();
        builder.Property(b => b.ApartmentID).IsRequired(true);
        builder.Property(b => b.BillingDate).IsRequired(true);
        builder.Property(b => b.BillAmount).IsRequired(true);
        builder.Property(b => b.RentAmount).IsRequired(true);
               
        // relationships 
        builder.HasOne(b => b.Apartment)
               .WithMany(a => a.Bills) 
               .HasForeignKey(b => b.ApartmentID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.Payments) 
               .WithOne(p => p.Billing) 
               .HasForeignKey(p => p.BillingID) 
               .OnDelete(DeleteBehavior.Restrict);
    }
}
