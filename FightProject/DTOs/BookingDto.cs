namespace FlightProject.DTOs
{
    public class BookingDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public int Status { get; set; }
    }
}
