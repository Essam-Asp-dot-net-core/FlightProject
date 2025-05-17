namespace FlightProject.DTOs
{
    public class PaymentDtocs
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
