namespace FitnessTicketApp.Models.Domain
{
	public class UserMemberships
	{
		public Guid Id { get; set; }

		public string MembershipName { get; set; }

		public DateTime PurchaseId { get; set; }

		public int CheckIns { get; set; }

		public int Price { get; set; }

		public string Barcode { get; set; }

		public Boolean Valability { get; set; }

		public DateTime FirstCheckInDate { get; set; }

	}
}
