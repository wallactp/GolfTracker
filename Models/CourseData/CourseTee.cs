using System;

namespace GolfTracker.Models.CourseData
{
    public class CourseTee
    {
        public Guid CourseTeeId { get; set; }
        public string Name { get; set; }
        public int FrontYardage { get; set; }
        public int BackYardage { get; set; }
        public int CourseYardage => FrontYardage + BackYardage;
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}