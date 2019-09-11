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
        protected WordsAPIGrainServiceClient(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything) =>
            GrainService.GetWordInfoAsync(word, endpoint);

        public Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything) =>
            GrainService.GetWordInfoAsync<T>(word, endpoint);
    }
}
