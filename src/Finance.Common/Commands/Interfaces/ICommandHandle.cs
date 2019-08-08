using System.Threading.Tasks;

namespace Finance.Common.Commands.Infertaces
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}