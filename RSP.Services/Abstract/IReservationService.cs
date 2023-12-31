using RSP.Data.Entity;
using RSP.Services.Models;

namespace RSP.Services.Abstract
{
    public interface IReservationService
    {
        Task<string> CreateReservation(ReservationCreateDto reservationCreateDto);

        Task<List<Reservation>> GetAllReservations();
    }
}
