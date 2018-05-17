using System;

namespace GolfTracker.Models.Shared
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}