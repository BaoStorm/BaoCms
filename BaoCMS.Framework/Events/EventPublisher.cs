using BaoCMS.Framework.Resolver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoCMS.Framework.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IResolver _resolver;

        public EventPublisher(IResolver resolver)
        {
            _resolver = resolver;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = GetHandlers<IEventHandler<TEvent>, TEvent>(@event);

            foreach (var handler in eventHandlers)
                handler.Handle(@event);
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = GetHandlers<IEventHandlerAsync<TEvent>, TEvent>(@event);

            foreach (var handler in eventHandlers)
                await handler.HandleAsync(@event);
        }

        private IEnumerable<THandler> GetHandlers<THandler, TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            var eventHandlers = _resolver.ResolveAll<THandler>();

            return eventHandlers;
        }
    }
}
