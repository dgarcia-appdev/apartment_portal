using apartment_portal_api.Models.IssueTypes;
using apartment_portal_api.Models.Users;
using apartment_portal_api.Models.Statuses;

namespace apartment_portal_api.Models.Issues;

public partial class Issue
{
    public int UserId { get; set; }

    public int IssueTypeId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string Description { get; set; } = null!;

    public int StatusId { get; set; }

    // Linking properties for EF Core
    public virtual IssueType IssueType { get; set; } = null!;
    public virtual Status Status { get; set; } = null!;
    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
