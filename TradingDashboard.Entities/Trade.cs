using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradingDashboard.Entities
{
    public class Trade : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Contract { get; set; }

        public string Symbol { get; set; }

        public long Volume { get; set; }

        public AssetType Type { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Exchange> Exchanges { get; set; }
    }
}