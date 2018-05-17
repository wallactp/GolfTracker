using System;

namespace GolfTracker.Models.UserData
{
    public class HandicapHistory 
    {
        public Guid HandicapHistoryId { get; set; }
        public DateTime Date { get; set; }
        public double Handicap { get; set; }
        public bool BiMonthlyUpdate { get; set; }
        public ApplicationUser User { get; set; }
    }
}