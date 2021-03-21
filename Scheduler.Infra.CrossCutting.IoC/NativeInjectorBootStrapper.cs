using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Application.Interfaces;
using Scheduler.Application.Services;
using Scheduler.Domain.Commands;
using Scheduler.Domain.Core.Events;
using Scheduler.Domain.Core.Interfaces;
using Scheduler.Domain.Interfaces;
using Scheduler.Infra.CrossCutting.Bus;
using Scheduler.Infra.Data.Context;
using Scheduler.Infra.Data.EventSourcing;
using Scheduler.Infra.Data.Repository;
using Scheduler.Infra.Data.Repository.EventSourcing;

namespace Scheduler.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<SchedulerApiContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}