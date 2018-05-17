using System;
using GolfTracker.Models.CourseData;
using GolfTracker.Models.Enums;

namespace GolfTracker.Models.RoundData
{
    public class HolePlayed
    {
        public Guid HolePlayedId { get; set; }
        public int Score { get; set; }
        public int NumberOfPutts { get; set; }
        public bool GreenInRegulation { get; set; }
        public SuccessTypes FairwayInRegulation { get; set; }
        public SuccessTypes UpAndDown { get; set; }
        public SuccessTypes SandSave { get; set; }
        public string Notes { get; set; }
        
        public Guid HoleId { get; set; }
        public Hole Hole { get; set; }
        public Guid RoundId { get; set; }
        public Round Round { get; set; }
    }
}