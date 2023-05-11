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
    }
}
