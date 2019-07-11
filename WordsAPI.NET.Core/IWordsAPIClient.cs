using System.Threading.Tasks;

namespace WordsAPI.NET.Core
{
	public interface IWordsAPIClient
	{
		Task<string> GetWordInfoAsync(string word, Endpoint endpoint);
		Task<T> GetWordInfoAsync<T>(string word, Endpoint endpoint);
	}
}