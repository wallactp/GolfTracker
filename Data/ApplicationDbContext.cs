using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GolfTracker.Models;
using GolfTracker.Models.CourseData;
using GolfTracker.Models.EquipmentData;
using GolfTracker.Models.RoundData;
using GolfTracker.Models.Shared;
using GolfTracker.Models.UserData;

namespace GolfTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTee> CourseTees { get; set; }
        public DbSet<HandicapData> HandicapData { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubInSet> ClubsInSet { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<HolePlayed> HolesPlayed { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<HandicapHistory> HandicapHistories { get; set; }
        public DbSet<HomeCourse> HomeCourses { get; set; }
    }
}
