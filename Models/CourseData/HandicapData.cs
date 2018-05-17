using System;

namespace GolfTracker.Models.CourseData
{
    public class HandicapData
    {
        public Guid HandicapDataId { get; set; }
        public int FrontSlope { get; set; }
        public int BackSlope { get; set; }
        public int CourseSlope { get; set; }
        public double FrontRating { get; set; }
        public double BackRating { get; set; }
        public double CourseRating => FrontRating + BackRating;
        public Guid CourseTeeId { get; set; }
        public CourseTee CourseTee { get; set; }
    }
}