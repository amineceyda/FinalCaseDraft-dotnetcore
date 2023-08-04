using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using SiteManangmentAPI.Base.BaseEntities;

namespace SiteManangmentAPI.Data.Entities;

[Table("Messages", Schema = "dbo")]
public class Message : BaseEntity
{
    public int SenderUserID { get; set; } // Foreign Key to Users
    public int ReceiverUserID { get; set; } // Foreign Key to Users

    public string MessageContent { get; set; }
    public bool IsRead { get; set; }

    public virtual User SenderUser { get; set; }
    public virtual User ReceiverUser { get; set; }
}
//Configuration
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages", "dbo");

        builder.Property(m => m.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(m => m.InsertTime).IsRequired();
        builder.Property(m => m.SenderUserID).IsRequired();
        builder.Property(m => m.ReceiverUserID).IsRequired();
        builder.Property(m => m.MessageContent).IsRequired();
        builder.Property(m => m.IsRead).IsRequired();
        
               
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
