using Microsoft.Data.Entity;
using System.Configuration;
using WhereWeLunch.Models;
using WhereWeLunch.Models.Contracts;

namespace WhereWeLunch
{
    public class EntitiesContext : DbContext, IEntitiesContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<HungryProfessional> HungryProfessionals { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["WWLContext"].ConnectionString;
            optionsBuilder.UseSqlServer(stringConexao);
            base.OnConfiguring(optionsBuilder);
        }
    }
}