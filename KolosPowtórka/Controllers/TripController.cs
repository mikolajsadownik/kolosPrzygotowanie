using KolosPowtórka.Enums;
using KolosPowtórka.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KolosPowtórka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _repository;

        public TripController(ITripRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("trips")]
        public async Task<IActionResult> GePrescriptionAsync(int id)
        {
            var wyn = await _repository.GetTripsAsync();
            if (wyn is StatusEnum)
            {
                switch(wyn)
                {
                    case StatusEnum.NoTrips: return Conflict("Nie ma tripów");
                }
            }
            return Ok(wyn);

        }
    }
}
