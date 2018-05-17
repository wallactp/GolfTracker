using System;
using System.Collections.Generic;
using GolfTracker.Models.RoundData;

namespace GolfTracker.Models.CourseData
{
    public class Hole
    {
        public Guid HoleId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
        public int Yardage { get; set; }
        public Guid CourseTeeId { get; set; }
        public CourseTee CourseTee { get; set; }
        public IEnumerable<HolePlayed> HolesPlayed { get; set; }
    }
}