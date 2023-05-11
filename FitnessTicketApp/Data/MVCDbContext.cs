using FitnessTicketApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitnessTicketApp.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BerletTipus> BerletTipusok { get; set; }
    }
}
