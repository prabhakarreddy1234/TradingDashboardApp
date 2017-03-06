using Microsoft.Owin;
using Owin;
using TradingDashboard.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace TradingDashboard.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}