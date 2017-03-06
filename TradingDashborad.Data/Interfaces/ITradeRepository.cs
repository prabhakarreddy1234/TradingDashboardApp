using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TradingDashboard.Entities;

namespace TradingDashborad.Data.Interfaces
{
    public interface ITradeRepository
    {
        Task<ICollection<Trade>> Get();

        Task<Trade> GetById(Guid id);

        Task<Trade> Add(Trade trade);

        Task<Trade> Update(Guid id, Trade trade);

        Task<Trade> Patch(Guid id, JsonPatchDocument<Trade> patchTrade);

        Task<bool> Delete(Guid id);

        Task<bool> Exists(Guid id);
    }
}