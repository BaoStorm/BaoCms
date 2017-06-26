using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Events
{
    public static class EventFactory
    {
        public static dynamic CreateConcreteEvent(object @event)
        {
            Type type = @event.GetType();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap(type, type); });
            IMapper mapper = config.CreateMapper();
            dynamic result = mapper.Map(@event, type, type);
            return result;
        }
    }
}
