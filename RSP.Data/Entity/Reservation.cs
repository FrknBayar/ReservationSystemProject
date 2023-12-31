using RSP.Data.Enums;

namespace RSP.Data.Entity
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public Status ReservationStatus { get; set; }
        public string CustomerName { get; set; }
        public string CustomersCompanyName { get; set; }
    }
}
