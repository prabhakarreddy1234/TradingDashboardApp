using TradingDashborad.Data.Interfaces;

namespace TradingDashborad.Data
{
    public class DbContextFactory : IDbContextFactory<TraderContext>
    {
        public TraderContext GetContext()
        {
            return new TraderContext();
        }
    }
}