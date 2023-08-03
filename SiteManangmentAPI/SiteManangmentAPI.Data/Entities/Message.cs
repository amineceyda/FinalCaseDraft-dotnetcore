using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManangmentAPI.Data.Entities;

[Table("Messages", Schema = "dbo")]
public class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MessageID { get; set; } // Primary Key
    public int SenderUserID { get; set; } // Foreign Key to Users
    public int ReceiverUserID { get; set; } // Foreign Key to Users

    public string MessageContent { get; set; }
    public bool IsRead { get; set; }
    public DateTime DateSent { get; set; }

    public virtual User SenderUser { get; set; }
    public virtual User ReceiverUser { get; set; }
}
//Configuration
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages", "dbo");

        builder.Property(m => m.MessageID).IsRequired(true).UseIdentityColumn();
        builder.Property(m => m.SenderUserID).IsRequired();
        builder.Property(m => m.ReceiverUserID).IsRequired();
        builder.Property(m => m.MessageContent).IsRequired();
        builder.Property(m => m.IsRead).IsRequired();
        builder.Property(m => m.DateSent).IsRequired();
               
        //relationships 
        builder.HasOne(m => m.SenderUser)
               .WithMany(u => u.SentMessages)
               .HasForeignKey(m => m.SenderUserID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.ReceiverUser)
               .WithMany(u => u.ReceivedMessages) 
               .HasForeignKey(m => m.ReceiverUserID) 
               .OnDelete(DeleteBehavior.Restrict);
    }
}
