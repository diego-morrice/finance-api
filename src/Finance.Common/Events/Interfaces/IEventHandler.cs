using System.Threading.Tasks;

namespace Finance.Common.Events.Interfaces
{
    public interface IEventHandler<in T> where T : IEvent
    {
         Task HandleAsync(T @event);
    }
}