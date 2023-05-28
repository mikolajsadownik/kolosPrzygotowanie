using KolosPowtórka.Enums;
using KolosPowtórka.Models;
using KolosPowtórka.ModelsDTO;
using KolosPowtórka.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KolosPowtórka.Repositories.Implementations
{
    public class ClientTripRepository : IClientTripRepository
    {
        public MasterContext _context;
        public ClientTripRepository(MasterContext context)
        {
            _context = context;
        }


        public async Task<StatusEnum> AddClientToTripAsync(int id, ClientTripDTO ClientTripDTO)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {

                var DoesClientExist = await _context.Clients.FirstOrDefaultAsync(x => x.Pesel == ClientTripDTO.Pesel);
                if (DoesClientExist == null)
                {
                    await _context.Clients.AddAsync(new Client
                    {
                        FirstName = ClientTripDTO.FirstName,
                        LastName = ClientTripDTO.LastName,
                        Email = ClientTripDTO.Email,
                        Telephone = ClientTripDTO.Telephone,
                        Pesel = ClientTripDTO.Pesel
                    });

                    await _context.SaveChangesAsync();
                }


                var DoesTripExists = await _context.Trips.AnyAsync(x => x.IdTrip == ClientTripDTO.IdTrip);
                if (DoesTripExists)
                {
                    await transaction.RollbackAsync();
                    return StatusEnum.TripDoesNotExist;
                }
                var OurClient = await _context.Clients.FirstOrDefaultAsync(x => x.Pesel == ClientTripDTO.Pesel);

                var IsClientAddedToTrip = await _context.ClientTrips.AnyAsync(x => x.IdClient == OurClient.IdClient);

                if (IsClientAddedToTrip)
                {
                    await transaction.RollbackAsync();
                    return StatusEnum.IsAddedToTripAlready;
                }

                await _context.ClientTrips.AddAsync(new ClientTrip
                {
                    IdClient = OurClient.IdClient,
                    IdTrip = ClientTripDTO.IdTrip,
                    RegisteredAt = DateTime.Now,
                    PaymentDate = ClientTripDTO.PaymentDate
                });

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return StatusEnum.AddedClientToTrip;
            }  
        }
    }
}
