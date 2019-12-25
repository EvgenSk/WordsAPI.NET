using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Orleans.Configuration;
using Orleans.Providers;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WordsAPI.NET.Core;
using WordsAPI.NET.OrleansHostingExtensions;

namespace Orleans.Hosting
{
	public static class OrleansHostingExtensions
	{
		private static readonly Action<WordsAPIOptions> dummy = (_) => { };

		public static ISiloHostBuilder AddWordsAPIClient(this ISiloHostBuilder builder, string name, Action<WordsAPIOptions> configureOptions = null) =>
			builder.ConfigureServices(s => s.AddWordsAPIClient(name, ob => ob.Configure(configureOptions ?? dummy)));

		public static IServiceCollection AddWordsAPIClient(this IServiceCollection services, string name, Action<OptionsBuilder<WordsAPIOptions>> configureOptions = null)
		{
			configureOptions?.Invoke(services.AddOptions<WordsAPIOptions>(name));
			return
				services
				.ConfigureNamedOptionForLogging<WordsAPIOptions>(name)
				.AddSingletonNamedService(name, WordsAPIClientFactory.Create);
		}

		public static ISiloHostBuilder AddWordsAPIClient(this ISiloHostBuilder builder, Action<WordsAPIOptions> configureOptions = null) =>
			builder.ConfigureServices(s => s.AddWordsAPIClient(ob => ob.Configure(configureOptions ?? dummy)));

		public static IServiceCollection AddWordsAPIClient(this IServiceCollection services, Action<OptionsBuilder<WordsAPIOptions>> configureOptions = null)
		{
			configureOptions?.Invoke(services.AddOptions<WordsAPIOptions>());
			return
				services
				.AddSingleton<WordsAPIHttpService>()
				.AddSingleton<IWordsAPIClient, WordsAPIClient>();
		}

		public static ISiloHostBuilder AddWordsAPIGrainService(this ISiloHostBuilder builder, Action<OptionsBuilder<WordsAPIOptions>> configureOptions)
		{
			return
				builder
				.AddGrainService<WordsAPIGrainService>()
				.ConfigureServices(services =>
				{
					configureOptions?.Invoke(services.AddOptions<WordsAPIOptions>());
					services
					.AddSingleton<WordsAPIHttpService>()
					.AddSingleton<IWordsAPIClient, WordsAPIClient>()
					.AddSingleton<IWordsAPIGrainService, WordsAPIGrainService>()
					.AddSingleton<IWordsAPIGrainServiceClient, WordsAPIGrainServiceClient>();
				});
		}

		public static ISiloHostBuilder AddWordsAPIGrainService(this ISiloHostBuilder builder, Action<WordsAPIOptions> configureOptions = null) =>
			builder.AddWordsAPIGrainService(ob => ob.Configure(configureOptions ?? dummy));
	}
}
