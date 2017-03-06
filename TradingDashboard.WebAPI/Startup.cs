using Microsoft.Owin;
using Owin;
using TradingDashboard.WebAPI;

[assembly: OwinStartup(typeof(Startup))]

namespace TradingDashboard.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
