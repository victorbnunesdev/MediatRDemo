using AutoMapper;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Models;

namespace Scheduler.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
