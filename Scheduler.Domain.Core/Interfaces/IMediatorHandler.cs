using FluentValidation.Results;
using System.Threading.Tasks;

namespace Scheduler.Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}