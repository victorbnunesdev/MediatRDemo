using FluentValidation.Results;
using MediatR;
using Scheduler.Domain.Core;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Domain.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email);

            //if (await _customerRepository.GetByEmail(customer.Email) != null)
            //{
            //    AddError("The customer e-mail has already been taken.");
            //    return ValidationResult;
            //}

            //customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}