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

        public WordsAPIGrainService(IServiceProvider services, IGrainIdentity id, Silo silo, ILoggerFactory loggerFactory, IGrainFactory grainFactory) 
            : base(id, silo, loggerFactory)
        {
            GrainFactory = grainFactory;
        }

        public Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything)
        {
            throw new NotImplementedException();
        }
    }
}
