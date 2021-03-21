using AutoMapper;
using FluentValidation.Results;
using Scheduler.Application.Interfaces;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Commands;
using Scheduler.Domain.Core.Interfaces;
using Scheduler.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(IMapper mapper, ICustomerRepository customerRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());

        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CustomerViewModel customer)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customer);
            return await _mediator.SendCommand(registerCommand);
        }

        public Task<ValidationResult> Remove(Guid customer)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(CustomerViewModel customer)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
         {
            GC.SuppressFinalize(this);
        }
    }
}
