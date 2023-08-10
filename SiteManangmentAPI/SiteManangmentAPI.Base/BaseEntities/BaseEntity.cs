
namespace SiteManangmentAPI.Base.BaseEntities;

public class BaseEntity
{
    public int Id { get; set; } //Primary Key for entities
    public DateTime InsertTime { get; set; }
    public DateTime UpdateTime { get; set; }

}
