using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Application.Interfaces;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Models;

namespace Scheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetCustomer()
        {
            return await _customerAppService.GetAll();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<CustomerViewModel> GetCustomer(Guid id)
        {
            return await _customerAppService.GetById(id);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(CustomerViewModel customer)
        {
            return !ModelState.IsValid ? CustomResponse() : CustomResponse(await _customerAppService.Update(customer));
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerViewModel customer)
        {
            return !ModelState.IsValid ? CustomResponse() : CustomResponse(await _customerAppService.Register(customer));
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            return CustomResponse(await _customerAppService.Remove(id));
        }
    }
}
