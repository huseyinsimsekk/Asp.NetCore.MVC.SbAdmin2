using Microsoft.Extensions.DependencyInjection;
using SbAdmin2.Core.Contracts;
using SbAdmin2.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbAdmin2.Web.Extensions
{
    public static class StartupExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAlertService, AlertService>();
        }
    }
}
