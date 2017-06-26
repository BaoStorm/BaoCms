using System;
using System.Collections.Generic;

namespace BaoCMS.Framework.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
        ICollection<IDomainEvent> Events { get; }
    }
}
