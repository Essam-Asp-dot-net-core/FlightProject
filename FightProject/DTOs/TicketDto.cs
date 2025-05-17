namespace FlightProject.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public string SeatNumber { get; set; }
        public string Class { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
    }
}
