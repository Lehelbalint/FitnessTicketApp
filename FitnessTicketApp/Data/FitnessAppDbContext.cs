using FitnessTicketApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitnessTicketApp.Data
{
    public class FitnessAppDbContext : DbContext
    {
        public FitnessAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<BerletTipus> BerletTipusok { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<ClientTicket> ClientsTickets { get; set; }
    }
}
