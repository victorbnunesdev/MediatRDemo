using System.Threading.Tasks;

namespace Scheduler.Domain.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}