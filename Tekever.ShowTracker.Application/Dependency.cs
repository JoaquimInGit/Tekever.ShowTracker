using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Application
{
	public static class Dependency
	{
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services = services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
