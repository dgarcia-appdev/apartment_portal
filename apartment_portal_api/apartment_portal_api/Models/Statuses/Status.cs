using apartment_portal_api.Models.Issues;
using apartment_portal_api.Models.Packages;
using apartment_portal_api.Models.Users;

namespace apartment_portal_api.Models.Statuses;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    // Linking properties for EF Core
    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
