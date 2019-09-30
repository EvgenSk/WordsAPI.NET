using Orleans.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsAPI.NET.Core;

namespace WordsAPI.NET.OrleansHostingExtensions
{
	public interface IWordsAPIGrainService : IGrainService
	{
		Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything);
		Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything);
	}
}
