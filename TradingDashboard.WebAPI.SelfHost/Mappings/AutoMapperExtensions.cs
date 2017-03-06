using System.Collections.Generic;
using Marvin.JsonPatch;
using TradingDashboard.Entities;
using TradingDashboard.WebAPI.Representations;

namespace TradingDashboard.WebAPI.Mappings
{
    public static class AutoMapperExtensions
    {
        public static Trade ToEntity(this TradeRepresentation trade, Trade dest = null)
        {
            return AutoMapperConfiguration.ToEntity(trade, dest);
        }

        public static JsonPatchDocument<Trade> ToEntity(this JsonPatchDocument<TradeRepresentation> trade, JsonPatchDocument<Trade> dest = null)
        {
            return AutoMapperConfiguration.ToEntity(trade, dest);
        }

        public static TradeRepresentation ToRepresentation(this Trade trade)
        {
            return AutoMapperConfiguration.ToRepresentation(trade);
        }

        public static ICollection<TradeRepresentation> ToRepresentation(this ICollection<Trade> trades)
        {
            return AutoMapperConfiguration.ToRepresentation(trades);
        }
    }
}