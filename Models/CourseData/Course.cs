using System;
using GolfTracker.Models.Shared;

namespace GolfTracker.Models.CourseData
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}