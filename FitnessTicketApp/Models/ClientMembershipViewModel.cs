using FitnessTicketApp.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessTicketApp.Models
{
    public class ClientMembershipViewModel
    {
        public List<Client> Clients { get; set; }
        public List<BerletTipus> MemberShip { get; set; }
        public Guid SelectedFelhasznaloId { get; set; }
        public Guid SelectedBerletId { get; set; }

        public DateTime StartDate { get; set; }
    }
}