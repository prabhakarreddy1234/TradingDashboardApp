using System.Web.Http;
using Microsoft.Practices.Unity;
using TradingDashborad.Data;
using TradingDashborad.Data.Interfaces;
using TradingDashborad.Data.Repositories;
using Unity.WebApi;

namespace TradingDashboard.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IDbContextFactory<TraderContext>, DbContextFactory>();
            container.RegisterType<ITradeRepository, TradeRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}