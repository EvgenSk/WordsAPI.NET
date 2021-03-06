﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Concurrency;
using Orleans.Core;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsAPI.NET.Core;

namespace WordsAPI.NET.OrleansHostingExtensions
{
	[Reentrant]
	public class WordsAPIGrainService : GrainService, IWordsAPIGrainService
	{
		private readonly IWordsAPIClient Client;

		public WordsAPIGrainService(IWordsAPIClient client, IGrainIdentity id, Silo silo, ILoggerFactory loggerFactory)
			: base(id, silo, loggerFactory)
		{
			Client = client;
		}

		public Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything) =>
			Client.GetWordInfoAsync(word, endpoint);

		public Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything) =>
			Client.GetWordInfoAsync<T>(word, endpoint);
	}
}
