namespace VillaAgency.Models.Entities;

public class PropertyType : BaseEntity
{
    public string Name { get; set; } = string.Empty; // "Apartment", "Villa House", "Penthouse", "Modern Condo", "Luxury Villa"
    public string Description { get; set; } = string.Empty;

    public ICollection<Property> Properties { get; set; } = new List<Property>();
}