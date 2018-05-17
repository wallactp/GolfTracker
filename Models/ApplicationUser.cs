using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfTracker.Models.EquipmentData;
using GolfTracker.Models.RoundData;
using GolfTracker.Models.Shared;
using GolfTracker.Models.UserData;
using Microsoft.AspNetCore.Identity;

namespace GolfTracker.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public DateTime Created { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public IEnumerable<HandicapHistory> HandicapHistory { get; set; }
        public IEnumerable<HomeCourse> HomeCourses { get; set; }
        public IEnumerable<Set> ClubSets { get; set; }
    }
}
