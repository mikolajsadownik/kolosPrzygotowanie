using KolosPowtórka.Enums;
using KolosPowtórka.ModelsDTO;

namespace KolosPowtórka.Repositories.Interfaces
{
    public interface IClientTripRepository
    {
        public Task<StatusEnum> AddClientToTripAsync(int id, ClientTripDTO ClientTripDTO);
    }
}
