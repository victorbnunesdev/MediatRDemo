using Scheduler.Domain.Core;
using Scheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(Guid id);

        void Add(Customer customer);
    }
}