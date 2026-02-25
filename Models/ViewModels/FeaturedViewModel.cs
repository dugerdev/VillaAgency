using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VillaAgency.Models.Entities;

namespace VillaAgency.Models.ViewModels;

public class FeaturedViewModel
{
    public Entities.Property FeaturedProperty { get; set; }
    public List<FAQ> FAQs { get; set; }
}
