
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManangmentAPI.Base.BaseEntities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } //Primary Key for entities
    public DateTime InsertTime { get; set; }
    public DateTime UpdateTime { get; set; }

}
