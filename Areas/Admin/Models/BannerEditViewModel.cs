namespace VillaAgency.Areas.Admin.Models
{
    public class BannerEditViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public string LinkedinUrl { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
        public string ExistingImageUrl { get; set; } = string.Empty;
    }
}
