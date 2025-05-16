namespace FlightProject.DTOs
{
	public class FlightSearchDTO
	{
		
			public string FromCity { get; set; }
			public string ToCity { get; set; }
			public DateTime TravelDate { get; set; }
			public string FlightClass { get; set; } // Optional: Economy/Business
		

	}
}

