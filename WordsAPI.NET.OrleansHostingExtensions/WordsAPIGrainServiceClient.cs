using Orleans.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsAPI.NET.Core;

namespace WordsAPI.NET.OrleansHostingExtensions
{
	public class WordsAPIGrainServiceClient : GrainServiceClient<IWordsAPIGrainService>, IWordsAPIGrainServiceClient
	{
		private readonly IWordsAPIClient client;

		public WordsAPIGrainServiceClient(IServiceProvider serviceProvider, IWordsAPIClient client)
			: base(serviceProvider)
		{
			this.client = client;
		}

		public Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything) =>
			client.GetWordInfoAsync(word, endpoint);

		public Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything) =>
			client.GetWordInfoAsync<T>(word, endpoint);
	}
}
