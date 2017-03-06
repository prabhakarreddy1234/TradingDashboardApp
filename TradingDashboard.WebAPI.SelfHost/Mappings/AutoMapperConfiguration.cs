using System.Collections.Generic;
using AutoMapper;
using Marvin.JsonPatch;
using TradingDashboard.Entities;
using TradingDashboard.WebAPI.Representations;

namespace TradingDashboard.WebAPI.Mappings
{
    public class AutoMapperConfiguration
    {
        public static IMapper MapperInstance { get; set; }

        static AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ModelsMapProfile>(); });

            MapperInstance = config.CreateMapper();

            config.AssertConfigurationIsValid();
        }

        public static Trade ToEntity(TradeRepresentation representation, Trade dest = null)
        {
            return representation == null ? null : MapperInstance.Map(representation, dest);
        }

        public static JsonPatchDocument<Trade> ToEntity(JsonPatchDocument<TradeRepresentation> representation, JsonPatchDocument<Trade> dest = null)
        {
            return representation == null ? null : MapperInstance.Map(representation, dest);
        }

        public static TradeRepresentation ToRepresentation(Trade trade)
        {
            return trade == null ? null : MapperInstance.Map<Trade, TradeRepresentation>(trade);
        }


        public static ICollection<TradeRepresentation> ToRepresentation(ICollection<Trade> trades)
        {
            return MapperInstance.Map<ICollection<Trade>, ICollection<TradeRepresentation>>(trades);
        }
    }
}