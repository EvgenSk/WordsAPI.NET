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
        readonly IGrainFactory GrainFactory;
        readonly WordsAPIClient Client;

        public WordsAPIGrainService(IServiceProvider services, IGrainIdentity id, Silo silo, ILoggerFactory loggerFactory, IGrainFactory grainFactory) 
            : base(id, silo, loggerFactory)
        {
            GrainFactory = grainFactory;
            Client = WordsAPIClientFactory.Create(services);
        }

        public Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything) =>
            Client.GetWordInfoAsync(word, endpoint);

        public Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything) =>
            Client.GetWordInfoAsync<T>(word, endpoint);
    }
}
