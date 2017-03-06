using System.Data.Entity;
using TradingDashboard.Entities;

namespace TradingDashborad.Data
{
    public class TraderContext : DbContext
    {
        public TraderContext()
            : base("TradingDashboardDb")
        {
            
        }

        public virtual DbSet<Trade> Trades { get; set; }

        public virtual DbSet<Exchange> Exchanges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}