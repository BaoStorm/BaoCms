using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
