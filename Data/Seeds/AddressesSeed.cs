using System.Collections.Generic;
using System.Threading.Tasks;
using GolfTracker.Models.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GolfTracker.Data.Seeds
{
    public class AddressesSeed
    {
        private readonly ApplicationDbContext _context;

        public AddressesSeed(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Seed()
        {
            var address = _context.Addresses.Add(
                new Address 
                {
                    Street1 = "900 Terminal Pl",
                    Street2 = "Apt 13",
                    City = "Richmond",
                    State = "VA",
                    ZipCode = "23220"
                }
            );

            return address.Entity;
        }
    }
}