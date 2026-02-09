using Microsoft.AspNetCore.Identity;

namespace VillaAgency.Models.Entities;

public class AppilcationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}
