using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TravelPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string Name {get; set; }
        public List<Trip> Trips { get; set;}

        
    }
}