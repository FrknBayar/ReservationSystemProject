using Microsoft.AspNetCore.Mvc;
using RSP.Services.Abstract;
using RSP.Services.Models;

namespace RSP.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewReservation([FromBody] ReservationCreateDto reservationCreateDto)
        {
            return Ok(await _reservationService.CreateReservation(reservationCreateDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            return Ok(await _reservationService.GetAllReservations());
        }
    }
}
