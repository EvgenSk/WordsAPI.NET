using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WordsAPI.NET.Core
{
	public class WordsAPIHttpService
	{
		public HttpClient Client { get; } = new HttpClient();

		public WordsAPIHttpService(IOptions<WordsAPIOptions> options)
		{
			Client.BaseAddress = new Uri(options.Value.BaseURL);
			Client.DefaultRequestHeaders.Add("X-RapidAPI-Host", options.Value.RapidAPIHost);
			Client.DefaultRequestHeaders.Add("X-RapidAPI-Key", options.Value.RapidAPIKey);
		}

		public Task<string> GetWordInfoRawString(Endpoint endpoint, string word) =>
			Client.GetStringAsync(GetUriString(endpoint, word));

		public Task<HttpResponseMessage> GetAsync(Endpoint endpoint, string word) =>
			Client.GetAsync(GetUriString(endpoint, word));

		private static string GetUriString(Endpoint endpoint, string word)
		{
			var strEndpoint =
				endpoint == Endpoint.Everything
				? string.Empty
				: endpoint.ToString().ToLowerInvariant();

			return $"/words/{word}/{strEndpoint}";
		}
	}

	public enum Endpoint
	{
		Everything,
		Frequency
	}

	public static class WordsAPIHttpServiceFactory
	{
		public static WordsAPIHttpService Create(IServiceProvider services)
		{
			IOptionsSnapshot<WordsAPIOptions> optionsSnapshot = services.GetRequiredService<IOptionsSnapshot<WordsAPIOptions>>();
			return ActivatorUtilities.CreateInstance<WordsAPIHttpService>(services, optionsSnapshot);
		}

		public static WordsAPIHttpService Create(IServiceProvider services, string name)
		{
			IOptionsSnapshot<WordsAPIOptions> optionsSnapshot = services.GetRequiredService<IOptionsSnapshot<WordsAPIOptions>>();
			return ActivatorUtilities.CreateInstance<WordsAPIHttpService>(services, optionsSnapshot.Get(name));
		}
	}
}
