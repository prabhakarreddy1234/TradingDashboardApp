using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradingDashboard.Entities
{
    public class Exchange : BaseEntity
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Trade> Trades { get; set; }
    }
}