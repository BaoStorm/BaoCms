using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public ICollection<IDomainEvent> Events { get; protected set; } = new List<IDomainEvent>();

        public bool IsDelete { get; protected set; }
        public Guid CreateUserId { get; protected set; }
        public DateTime CraeteDateTime { get; protected set; }
        public Guid UpdateUserId { get; protected set; }
        public Guid UpdateDateTime { get; protected set; }

        protected AggregateRoot()
        {
            Id = Guid.Empty;
        }

        protected AggregateRoot(Guid id)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();

            Id = id;
        }

        protected void AddEvent(IDomainEvent @event)
        {
            Events.Add(@event);
        }
    }
}
