using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using TradingDashboard.Entities;

namespace TradingDashborad.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TraderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TraderContext context)
        {
            #region Add Exchanges 

            var nyse = new Exchange
                           {
                               Code = "NYSE",
                               Name = "New York Stock Exchange"
                           };

            var dax = new Exchange
                          {
                              Code = "DAX",
                              Name = "German Stock Exchange"
                          };

            var ftse = new Exchange
                           {
                               Code = "FTSE",
                               Name = "London Stock Exchange"
                           };

            var cac = new Exchange
                          {
                              Code = "CAC",
                              Name = "France Stock Exchange"
                          };

            context.Exchanges.AddOrUpdate(dax);
            context.Exchanges.AddOrUpdate(cac);

            context.Exchanges.AddOrUpdate(ftse);

            context.Exchanges.AddOrUpdate(nyse);

            #endregion

            #region Add Trades

            var trade1 = new Trade
                             {
                                 Contract = "OIL",
                                 Symbol = "CRUDEOIL",
                                 Id = Guid.NewGuid(),
                                 Volume = 1000,
                                 Price = 39.14,
                                 Exchanges = new List<Exchange>
                                                 {
                                                     cac,
                                                     ftse
                                                 },
                                 Type = AssetType.Commodity
                             };

            var trade2 = new Trade
                             {
                                 Contract = "Currency",
                                 Symbol = "GBPUSD",
                                 Id = Guid.NewGuid(),
                                 Volume = 1500,
                                 Price = 1.2345,
                                 Exchanges = new List<Exchange>
                                                 {
                                                     nyse,
                                                     dax
                                                 },
                                 Type = AssetType.Forex
                             };

            var trade3 = new Trade
                             {
                                 Contract = "Indces",
                                 Symbol = "NYSE",
                                 Id = Guid.NewGuid(),
                                 Volume = 1000,
                                 Price = 2350,
                                 Exchanges = new List<Exchange>
                                                 {
                                                     nyse
                                                 },
                                 Type = AssetType.Commodity
                             };

            context.Trades.AddOrUpdate(trade1);
            context.Trades.AddOrUpdate(trade2);
            context.Trades.AddOrUpdate(trade3);

            #endregion
        }
    }
}
