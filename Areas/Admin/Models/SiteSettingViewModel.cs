namespace VillaAgency.Areas.Admin.Models
{
    public class SiteSettingViewModel
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MapEmbedUrl { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
    }
}
