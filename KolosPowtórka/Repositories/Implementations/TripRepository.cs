using KolosPowtórka.Enums;
using KolosPowtórka.Models;
using KolosPowtórka.ModelsDTO;
using KolosPowtórka.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KolosPowtórka.Repositories.Implementations
{


    public class TripRepository : ITripRepository
    {
        public MasterContext _context;
        public TripRepository(MasterContext context)
        {
            _context = context;
        }

        public async Task<dynamic> GetTripsAsync()
        {



            var trips = await _context.Trips.Select(x => new TripDTO
            {
                Name = x.Name,
                Description = x.Description,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                MaxPeople = x.MaxPeople,
                Clients = x.ClientTrips.Select(x => new ClientDTO { FirstName = x.Client.FirstName , LastName = x.Client.LastName,}).ToList(),
                Countries = x.CountryTrips.Select(x => x.Country.Name).ToList(),
            }).ToListAsync();



            
            return trips;
        }
    }
}
