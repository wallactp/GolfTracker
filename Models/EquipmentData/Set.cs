using System;
using System.Collections.Generic;
using GolfTracker.Models.RoundData;

namespace GolfTracker.Models.EquipmentData
{
    public class Set
    {
        public Guid SetId { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<ClubInSet> ClubsInSet { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
    }
}