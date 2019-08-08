using System.Threading.Tasks;
namespace Finance.Common.ServiceBus.Interfaces
{
    public interface IServiceHost
    {
        Task RunAsync();
    }
}