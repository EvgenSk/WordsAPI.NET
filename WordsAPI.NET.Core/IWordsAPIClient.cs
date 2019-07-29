using System.Threading.Tasks;

namespace WordsAPI.NET.Core
{
	public interface IWordsAPIClient
	{
		Task<string> GetWordInfoAsync(string word, Endpoint endpoint = Endpoint.Everything);
		Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint = Endpoint.Everything);
	}
}