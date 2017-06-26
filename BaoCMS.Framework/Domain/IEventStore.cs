using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoCMS.Framework.Domain
{
    public interface IEventStore
    {
        void SaveEvent<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot;
        Task SaveEventAsync<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot;
    }
}
