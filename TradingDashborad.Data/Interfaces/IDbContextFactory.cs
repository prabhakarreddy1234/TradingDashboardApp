namespace TradingDashborad.Data.Interfaces
{
    public interface IDbContextFactory<out T>
    {
        T GetContext();
    }
}