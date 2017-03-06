using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Marvin.JsonPatch;
using TradingDashboard.WebAPI.Mappings;
using TradingDashboard.WebAPI.Representations;
using TradingDashborad.Data.Interfaces;

namespace TradingDashboard.WebAPI.Controllers
{
    //[Authorize]    Not implemented yet
    public class TradeController : ApiController
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        /// <summary>
        ///     Get Trades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Trades", Name = "GetTrades")]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _tradeRepository.Get();
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Get Trade by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Trade/{id}", Name = "GetTradeById")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var result = await _tradeRepository.GetById(id);
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Update Trade
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trade"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Trade/{id:guid}", Name = "UpdateTrade")]
        public async Task<IHttpActionResult> UpdateTrade([FromUri]Guid id, [FromBody] TradeRepresentation trade)
        {
            var result = await _tradeRepository.Update(id, trade.ToEntity());
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Add Trade
        /// </summary>
        /// <param name="trade"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Trade", Name = "AddTrade")]
        public async Task<IHttpActionResult> AddTrade([FromBody] TradeRepresentation trade)
        {
            var result = await _tradeRepository.Add(trade.ToEntity());
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Update Trade partially
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trade"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Trade/{id:guid}", Name = "PatchTrade")]
        public async Task<IHttpActionResult> PatchTrade(Guid id, [FromBody] JsonPatchDocument<TradeRepresentation> trade)
        {

            //Todo : Not working 

            return Ok(await _tradeRepository.Patch(id, trade.ToEntity()));
        }

        /// <summary>
        ///     Delete Trade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Trade/{id:guid}", Name = "DeleteTrade")]
        public async Task<IHttpActionResult> DeleteTrade(Guid id)
        {
            return Ok(await _tradeRepository.Delete(id));
        }
    }
}