using System;
using System.Collections.Generic;
using GolfTracker.Models.CourseData;
using GolfTracker.Models.Enums;

namespace GolfTracker.Models.RoundData
{
    public class Round
    {
        public Guid RoundId { get; set; }
        public DateTime Date { get; set; }
        public RoundLocationTypes RoundLocationType { get; set; }
        public RoundLengthTypes RoundLengthType { get; set; }

        public Guid CourseTeeId { get; set; }
        public Guid UserId { get; set; }
        public CourseTee CourseTee { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<HolePlayed> HolesPlayed { get; set; }
    }
}