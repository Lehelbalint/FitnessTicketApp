namespace FitnessTicketApp.Models.Domain
{
	public class CheckIns
	{
		public Guid Id { get; set; }

		public Guid ClientId { get; set; }

		public Guid TicketId { get; set; }

		public DateTime CheckInDate { get; set; }

		public string Barcode { get; set; }	

		public Guid GymId { get; set; }
	}
}
