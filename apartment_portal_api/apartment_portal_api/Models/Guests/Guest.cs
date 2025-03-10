using System.ComponentModel.DataAnnotations.Schema;
using apartment_portal_api.Models.Users;
using apartment_portal_api.Models.ParkingPermits;
using System;
using System.Collections.Generic;

namespace apartment_portal_api.Models.Guests;

public class Guest
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    
    public int AccessCode { get; set; }

    public DateTime Expiration { get; set; }
    public DateTime CreatedOn { get; set; }

    public virtual ICollection<ParkingPermit> ParkingPermits { get; set; } = new List<ParkingPermit>();

    [ForeignKey("UserId")]
    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
