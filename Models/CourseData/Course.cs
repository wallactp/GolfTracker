using System;
using System.Collections.Generic;
using GolfTracker.Models.Shared;
using GolfTracker.Models.UserData;

namespace GolfTracker.Models.CourseData
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<CourseTee> CourseTees { get; set; }
        public IEnumerable<HomeCourse> HomeCourses { get; set; }
    }
}