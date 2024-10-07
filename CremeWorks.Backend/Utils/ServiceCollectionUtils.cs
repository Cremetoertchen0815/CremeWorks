using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BV.Server.Utils;
public static class ServiceCollectionUtils
{
	public static void AddHostedService<TService, TImplementation>(this IServiceCollection services)
		where TService : class
		where TImplementation : class, IHostedService, TService
	{
		services.AddSingleton<TService, TImplementation>();
		services.AddHostedService<HostedServiceWrapper<TService>>();
	}
	public static void AddHostedServicePlusImplementation<TService, TImplementation>(this IServiceCollection services)
		where TService : class
		where TImplementation : class, IHostedService, TService
	{
		services.AddSingleton<TImplementation>();
		services.AddSingleton<TService>(x => x.GetRequiredService<TImplementation>());
		services.AddHostedService<HostedServiceWrapper<TImplementation>>();
	}
	public static void AddFindableHostedService<TImplementation>(this IServiceCollection services)
		where TImplementation : class, IHostedService
	{
		services.AddSingleton<TImplementation>();
		services.AddHostedService<HostedServiceWrapper<TImplementation>>();
	}

	private class HostedServiceWrapper<TService> : IHostedService
	{
		private readonly IHostedService _hostedService;

		public HostedServiceWrapper(TService hostedService)
		{
			if (hostedService is null) throw new ArgumentNullException(nameof(hostedService));
			_hostedService = (IHostedService)hostedService;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			return _hostedService.StartAsync(cancellationToken);
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return _hostedService.StopAsync(cancellationToken);
		}
	}
}