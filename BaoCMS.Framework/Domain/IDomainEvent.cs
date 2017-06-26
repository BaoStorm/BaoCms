using BaoCMS.Framework.Events;
using System;

namespace BaoCMS.Framework.Domain
{
    public interface IDomainEvent : IEvent
    {
        Guid AggregateRootId { get; set; }
        int Version { get; set; }
    }
}
