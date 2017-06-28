using BaoCMS.Data.Entities;
using BaoCMS.Framework.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEvent = BaoCMS.Data.Entities.DomainEvent;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaoCMS.Data.Extensions;

namespace BaoCMS.Data
{
    public class EventStore : IEventStore
    {
        private readonly IContextFactory _contextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventStore(IContextFactory contextFactory, IHttpContextAccessor httpContextAccessor)
        {
            _contextFactory = contextFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public void SaveEvent<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot
        {
            using (var context = _contextFactory.Create())
            {
                var aggregate = context.DomainAggregates.FirstOrDefault(x => x.Id == @event.AggregateRootId);

                if (aggregate == null)
                {
                    context.DomainAggregates.Add(new DomainAggregate
                    {
                        Id = @event.AggregateRootId,
                        Type = typeof(TAggregate).AssemblyQualifiedName
                    });
                }

                var currentSequenceCount = context.DomainEvents.Count(x => x.DomainAggregateId == @event.AggregateRootId);

                context.DomainEvents.Add(new DomainEvent
                {
                    DomainAggregateId = @event.AggregateRootId,
                    SequenceNumber = currentSequenceCount + 1,
                    Type = @event.GetType().AssemblyQualifiedName,
                    Body = JsonConvert.SerializeObject(@event),
                    TimeStamp = @event.TimeStamp,
                    UserId = _httpContextAccessor.GetUserId(context)
                });

                context.SaveChanges();
            }
        }

        public async Task SaveEventAsync<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot
        {
            using (var context = _contextFactory.Create())
            {
                var aggregate = await context.DomainAggregates.FirstOrDefaultAsync(x => x.Id == @event.AggregateRootId);

                if (aggregate == null)
                {
                    context.DomainAggregates.Add(new DomainAggregate
                    {
                        Id = @event.AggregateRootId,
                        Type = typeof(TAggregate).AssemblyQualifiedName
                    });
                }

                var currentSequenceCount = await context.DomainEvents.CountAsync(x => x.DomainAggregateId == @event.AggregateRootId);

                context.DomainEvents.Add(new DomainEvent
                {
                    DomainAggregateId = @event.AggregateRootId,
                    SequenceNumber = currentSequenceCount + 1,
                    Type = @event.GetType().AssemblyQualifiedName,
                    Body = JsonConvert.SerializeObject(@event),
                    TimeStamp = @event.TimeStamp,
                    UserId = _httpContextAccessor.GetUserId(context)
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
