using KolosPowtórka.Enums;
using KolosPowtórka.ModelsDTO;
using KolosPowtórka.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KolosPowtórka.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientTripController : ControllerBase
    {
        private readonly IClientTripRepository _repository;

        public ClientTripController(IClientTripRepository repository)
        {
            _repository = repository;
        }

        [Route("trips/{idTrip:int}/clients")]
        [HttpPost]
        public async Task<IActionResult> AddClientToTripAsync(int idTrip, ClientTripDTO ClientTripDTO)
        {
            var wyn = await _repository.AddClientToTripAsync(idTrip, ClientTripDTO);
            switch (wyn)
            {
                case StatusEnum.TripDoesNotExist: return BadRequest("Nie ma tripów");
                case StatusEnum.IsAddedToTripAlready: return Conflict("Klient już jest przypisany do wycieczki");
                    default: return Ok("Dodane klienta do wycieczki");
            }
           
        }
    }
   
}
