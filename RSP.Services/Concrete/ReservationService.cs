using Microsoft.EntityFrameworkCore;
using RSP.Data.Context;
using RSP.Data.Entity;
using RSP.Services.Abstract;
using RSP.Services.Models;

namespace RSP.Services.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly RSPContext _rspContext;

        public ReservationService(RSPContext rspContext)
        {
            _rspContext = rspContext;
        }

        public async Task<string> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            if (reservationCreateDto == null)
            {
                return "Cannot be null";
            }

            var existingReservation = await GetReservationByDate(reservationCreateDto.ReservationDate);

            if (existingReservation == null)
            {
                await _rspContext.Reservations.AddAsync(
                    new Reservation 
                    { 
                        ReservationDate = reservationCreateDto.ReservationDate, 
                        CustomerName = reservationCreateDto.CustomerName,
                        CustomersCompanyName = reservationCreateDto.CustomersCompanyName,
                        ReservationStatus = Data.Enums.Status.Active
                    });
                await _rspContext.SaveChangesAsync();
                return "Reservation created succesfully";
            }
            else
            {
                return "There is already a reservation for today";
            }
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _rspContext.Reservations.ToListAsync();
        }

        private async Task<Reservation> GetReservationByDate(DateTime dateTime)
        {
            return await _rspContext.Reservations.FirstOrDefaultAsync(x => x.ReservationDate == dateTime);
        }

        
    }
}
