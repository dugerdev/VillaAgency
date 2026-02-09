namespace WA_Blog.Models.Entities;

public class Property : BaseEntity
{
    public string Tittle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int Bathrooms { get; set; }
    public int BedRooms { get; set; }
    public decimal Area { get; set; }
    public int? Floor { get; set; }
    public string Parking { get; set; } = string.Empty;
    public decimal TotalFlatSpace { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsContractReady { get; set; }
    public string PaymentProcess { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;

    //Nav Prop
    public Guid PropertyTypeId { get; set; }
    public PropertyType PropertyType { get; set; }
    public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
}
