using System;
using System.Collections.Generic;

namespace GolfTracker.Models.EquipmentData
{
    public class Club
    {
        public Guid ClubId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ShaftFlex { get; set; }
        public string ShaftType { get; set; }
        public double Loft { get; set; }
        public double Length { get; set; }
        public double Lie { get; set; }
        public string GripSize { get; set; }
        public string GripType { get; set; }

        public IEnumerable<ClubInSet> Sets { get; set; }
    }
}