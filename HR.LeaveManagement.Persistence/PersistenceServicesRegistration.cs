using HR.LeaveManagement.Persistence.Repositories;
using HRLeaveManagement.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(
            this IServiceCollection service,
            IConfiguration config 
            )
        {

            service.AddDbContext<HRLeaveManagementDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("HRLeaveManagementConnectionString")));

            service.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            service.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            service.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            service.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return service;
        }
    }
}
