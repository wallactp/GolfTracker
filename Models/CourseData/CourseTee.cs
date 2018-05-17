using System;
using System.Collections.Generic;
using System.Linq;

namespace GolfTracker.Models.CourseData
{
    public class CourseTee
    {
        public Guid CourseTeeId { get; set; }
        public string Name { get; set; }
        public int FrontYardage => Holes.Where(hole => hole.Number <= 9).Sum(x => x.Yardage);
        public int BackYardage => Holes.Where(hole => hole.Number >= 10).Sum(x => x.Yardage);
        public int CourseYardage => FrontYardage + BackYardage;
        public Guid CourseId { get; set; }
        public Guid HandicapDataId { get; set; }
        public Course Course { get; set; }
        public HandicapData HandicapData { get; set; }
        public IEnumerable<Hole> Holes { get; set; }
    }
}