using System;
using System.Collections.Generic;

namespace GolfTracker.Models.EquipmentData
{
    public class ClubInSet 
    {
        public Guid ClubInSetId { get; set; }
        public Guid SetId { get; set; }
        public Guid ClubId { get; set; }
        public Set Set { get; set; }
        public Club Club { get; set; }
    }
}