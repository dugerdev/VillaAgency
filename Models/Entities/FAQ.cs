namespace VillaAgency.Models.Entities;

public class FAQ : BaseEntity 
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}
