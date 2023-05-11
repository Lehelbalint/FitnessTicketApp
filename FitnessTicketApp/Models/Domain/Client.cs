namespace FitnessTicketApp.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Boolean Is_deleted { get; set; }
        public byte[]? Photo  { get; set; }
        public DateTime inserted_date { get; set; }
        public string CNP { get; set; }
        public string Adress { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }
         
    }
}