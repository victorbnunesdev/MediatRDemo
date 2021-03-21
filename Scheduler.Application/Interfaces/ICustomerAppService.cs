using FluentValidation.Results;
using Scheduler.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(Guid id);
        Task<ValidationResult> Update(CustomerViewModel customer);
        Task<ValidationResult> Register(CustomerViewModel customer);
        Task<ValidationResult> Remove(Guid customer);
    }
}