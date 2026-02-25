namespace VillaAgency.Areas.Admin.Models
{
    public class FAQViewModel
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
