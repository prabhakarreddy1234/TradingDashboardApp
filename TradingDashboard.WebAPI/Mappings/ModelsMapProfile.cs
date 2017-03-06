using System.Linq;
using AutoMapper;
using TradingDashboard.Entities;
using TradingDashboard.WebAPI.Representations;

namespace TradingDashboard.WebAPI.Mappings
{
    public class ModelsMapProfile : Profile
    {
        public ModelsMapProfile()
        {
            #region Trade Mappings

            CreateMap<Trade, TradeRepresentation>()
                .ForMember(x => x.Exchange, opt => opt.MapFrom(src => string.Join(",", src.Exchanges.Select(x => x.Code))))
                .ForMember(x => x.InvestedAmount, opt => opt.MapFrom(src => src.Volume * src.Price))
                .ReverseMap()
                .ForMember(x => x.Exchanges, opt => opt.Ignore());

            #endregion
        }
    }
}