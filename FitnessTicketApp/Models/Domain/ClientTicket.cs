namespace FitnessTicketApp.Models.Domain
{
    public class ClientTicket
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid TicketId { get; set; }

        public DateTime PurchaseId { get; set; }

        public string CardId { get; set; }

        public int CheckIns { get; set; }

        public int Price { get; set; }

        public Boolean Valability { get; set; }

        public DateTime FirstCheckInDate{ get; set; }

        public Guid GymId { get; set; }
    }
}
