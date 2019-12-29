using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WordsAPI.NET.Core
{
	public class WordsAPIClient : IWordsAPIClient
	{
		private static JsonSerializerSettings jsonSerializerSettings =
			new JsonSerializerSettings
			{
				Converters = new List<JsonConverter> { new StringEnumConverter() },
				MissingMemberHandling = MissingMemberHandling.Ignore
			};

		WordsAPIHttpService WordsAPIHttpService { get; }

		public WordsAPIClient(WordsAPIHttpService service)
		{
			WordsAPIHttpService = service;
		}

		/// <summary>
		/// Get JSON string from WordsAPI
		/// </summary>
		/// <param name="word">Specific word to get information about</param>
		/// <param name="endpoint">Subset of properties</param>
		/// <returns>Task with JSON string in it</returns>
		public Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything) =>
			WordsAPIHttpService.GetWordInfoRawString(endpoint, word);

		/// <summary>
		/// Get WordInfo from WordsAPI (typed version)
		/// </summary>
		/// <param name="word">Specific word to get information about</param>
		/// <param name="endpoint">Subset of properties</param>
		/// <returns>Task with specific type in it</returns>
		public async Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything)
		{
			try
			{
				string rawString = await WordsAPIHttpService.GetWordInfoRawString(endpoint, word);
				return JsonConvert.DeserializeObject<T>(rawString, jsonSerializerSettings);
			}
			catch(Exception ex) // TODO: add logging
			{
				return default;
			}
		}
	}

	public static class WordsAPIClientFactory
	{
		public static WordsAPIClient Create(IServiceProvider services)
		{
			WordsAPIHttpService httpService = WordsAPIHttpServiceFactory.Create(services);
			return ActivatorUtilities.CreateInstance<WordsAPIClient>(services, httpService);
		}

		public static WordsAPIClient Create(IServiceProvider services, string name)
		{
			WordsAPIHttpService httpService = WordsAPIHttpServiceFactory.Create(services, name);
			return ActivatorUtilities.CreateInstance<WordsAPIClient>(services, httpService);
		}
	}
}
