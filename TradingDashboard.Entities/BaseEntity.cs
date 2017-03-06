using System;

namespace TradingDashboard.Entities
{
    public class BaseEntity
    {
        public Guid CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public Guid LastModifiedBy { get; set; }

        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}