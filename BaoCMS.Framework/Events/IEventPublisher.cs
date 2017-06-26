using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoCMS.Framework.Events
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
