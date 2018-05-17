using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfTracker.Models.RoundData;
using GolfTracker.Models.UserData;
using Microsoft.AspNetCore.Identity;

namespace GolfTracker.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Guid UserId { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public IEnumerable<HandicapHistory> HandicapHistory { get; set; }
        public IEnumerable<HomeCourse> HomeCourses { get; set; }
    }
}
