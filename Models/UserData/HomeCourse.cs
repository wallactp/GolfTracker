using System;
using GolfTracker.Models.CourseData;

namespace GolfTracker.Models.UserData
{
    public class HomeCourse
    {
        public Guid HomeCourseId { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public Course Course { get; set; }
        public ApplicationUser User { get; set; }
    }
}