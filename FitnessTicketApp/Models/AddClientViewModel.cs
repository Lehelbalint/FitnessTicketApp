namespace FitnessTicketApp.Models
{
    public class AddClientViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Boolean Is_deleted { get; set; }
        public byte[]? Photo { get; set; }
        public string CNP { get; set; }
        public string Adress { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }
    }
}
