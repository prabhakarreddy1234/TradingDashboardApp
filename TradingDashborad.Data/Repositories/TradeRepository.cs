using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TradingDashboard.Entities;
using TradingDashborad.Data.Interfaces;

namespace TradingDashborad.Data.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly IDbContextFactory<TraderContext> _contextFactory;

        public TradeRepository(IDbContextFactory<TraderContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<Trade>> Get()
        {
            using (var context = _contextFactory.GetContext()) {
                return await context.Trades.Include(t => t.Exchanges).Where(t => !t.IsDeleted).ToListAsync();
            }
        }

        public async Task<Trade> GetById(Guid id)
        {
            using (var context = _contextFactory.GetContext()) {
                return await context.Trades.Include(t => t.Exchanges).FirstOrDefaultAsync(t => !t.IsDeleted && t.Id == id);
            }
        }

        public async Task<bool> Exists(Guid id)
        {
            using (var context = _contextFactory.GetContext()) {
                return await context.Trades.AnyAsync(t => !t.IsDeleted && t.Id == id);
            }
        }

        public async Task<Trade> Add(Trade trade)
        {
            using (var dbContext = _contextFactory.GetContext())
            {
                trade.Id = Guid.NewGuid();
                trade.CreatedBy = Guid.NewGuid();
                trade.CreatedDate = DateTime.UtcNow;
                var addedTrade = dbContext.Trades.Add(trade);
                dbContext.SaveChanges();
                return await Task.FromResult(addedTrade);
            }
        }

        public async Task<Trade> Update(Guid id, Trade trade)
        {
            if (trade == null || id == Guid.Empty) { throw new ArgumentNullException(nameof(id)); }

            using (var dbContext = _contextFactory.GetContext())
            {
                var targetTrade = await dbContext.Trades.FirstOrDefaultAsync(t => t.Id == id);
                if (targetTrade == null)
                    throw new ArgumentNullException(nameof(targetTrade));
                targetTrade.Contract = trade.Contract;
                targetTrade.Price = trade.Price;
                targetTrade.Symbol = trade.Symbol;
                targetTrade.Type = trade.Type;
                targetTrade.Volume = trade.Volume;
                targetTrade.LastModifiedBy = Guid.NewGuid();
                targetTrade.LastModifiedDate = DateTime.UtcNow;

                dbContext.SaveChanges();
                return await GetById(id);
            }
        }

        public async Task<Trade> Patch(Guid id, JsonPatchDocument<Trade> patchTrade )
        {
            var trade = await GetById(id);
            patchTrade.ApplyTo(trade);

            return await GetById(id);
        }

        public async Task<bool> Delete(Guid id)
        {
            using (var context = _contextFactory.GetContext())
            {
                var itemToBeDeleted = await GetById(id);
                if (itemToBeDeleted == null)
                    return await Task.FromResult(false);
                context.Trades.Remove(itemToBeDeleted);
                return await Task.FromResult(true);
            }
        }
    }
}