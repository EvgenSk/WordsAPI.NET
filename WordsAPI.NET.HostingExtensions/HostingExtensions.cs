using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WordsAPI.NET.Core;

namespace Microsoft.Extensions.Hosting
{
	public static class HostingExtensions
	{
		public static IHostBuilder AddWordsAPIClient(this IHostBuilder hostBuilder, Action<WordsAPIOptions> configureOptions) =>
			hostBuilder.ConfigureServices(s => s.AddWordsAPIClient(ob => ob.Configure(configureOptions)));

		public static IServiceCollection AddWordsAPIClient(this IServiceCollection services, Action<OptionsBuilder<WordsAPIOptions>> configureOptions = null)
		{
			configureOptions?.Invoke(services.AddOptions<WordsAPIOptions>());
			return services.AddSingleton<IWordsAPIClient, WordsAPIClient>(WordsAPIClientFactory.Create);
		}
	}
}
