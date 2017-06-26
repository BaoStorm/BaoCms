
using System.Threading.Tasks;

namespace BaoCMS.Framework.Events
{
    public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
