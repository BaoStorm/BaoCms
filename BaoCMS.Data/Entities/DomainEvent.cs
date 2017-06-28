using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data.Entities
{
    public class DomainEvent
    {
        public Guid DomainAggregateId { get; set; }
        public int SequenceNumber { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid UserId { get; set; }

        public virtual DomainAggregate DomainAggregate { get; set; }
    }
}
