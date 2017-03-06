using System;

namespace TradingDashboard.WebAPI.Representations
{
    public class TradeRepresentation
    {
        public Guid Id { get; set; }

        public string Contract { get; set; }

        public string Symbol { get; set; }

        public long Volume { get; set; }

        public double InvestedAmount { get; set; } // Calculated on the run while Mapping

        public string Type { get; set; }

        public double Price { get; set; }

        public string Exchange { get; set; }
    }
}