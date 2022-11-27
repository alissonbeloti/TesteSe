using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace ViaCep.Application;

public static class ApplicationServiceRegistration
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddMediatR(Assembly.GetExecutingAssembly());

		return services;
	}
}
