using Scheduler.Domain.Core;
using System;

namespace Scheduler.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
    }
}