namespace WA_Blog.Models.Entities;

public class Banner : BaseEntity
{
    public string Tittle { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    public string LinkedinUrl { get; set; } = string.Empty;
}
