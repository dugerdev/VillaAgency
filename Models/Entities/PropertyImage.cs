namespace VillaAgency.Models.Entities;

public class PropertyImage : BaseEntity
{
    public Guid PropertyId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public int DisplayOrder { get; set; }

    //Nav Prop
    public Property Property { get; set; }
}
