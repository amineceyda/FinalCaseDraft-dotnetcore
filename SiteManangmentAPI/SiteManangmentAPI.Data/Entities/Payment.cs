
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManangmentAPI.Data.Entities;

[Table("Payments", Schema = "dbo")]
public class Payment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentID { get; set; } // Primary Key
    public int UserID { get; set; } // Foreign Key to user
    public int BillingID { get; set; } // Foreign Key to Billing

    public DateTime PaymentDate { get; set; }
    public decimal PaidAmount { get; set; }
    public string PaymentMethod { get; set; } = "Credit card";

    public virtual User User { get; set; }
    public virtual Billing Billing { get; set; }
}

//Configuration 
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments", "dbo");

        builder.Property(p => p.PaymentID).IsRequired(true).UseIdentityColumn();
        builder.Property(p => p.UserID).IsRequired();
        builder.Property(p => p.BillingID).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(p => p.PaidAmount).IsRequired();
        builder.Property(p => p.PaymentMethod).IsRequired().HasMaxLength(20);

        //relationships
        builder.HasOne(p => p.User)
               .WithMany(u => u.Payments) 
               .HasForeignKey(p => p.UserID) 
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Billing)
               .WithMany(b => b.Payments) 
               .HasForeignKey(p => p.BillingID) 
               .OnDelete(DeleteBehavior.Restrict); 
    }
}
