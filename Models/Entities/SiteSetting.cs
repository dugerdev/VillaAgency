namespace WA_Blog.Models.Entities;

public class SiteSetting : BaseEntity
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string MapEmbedUrl { get; set; } = string.Empty;
    public string SiteName { get; set; } = string.Empty;
}
