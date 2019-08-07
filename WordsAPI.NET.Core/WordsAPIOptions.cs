using System;
using System.Collections.Generic;
using System.Text;

namespace WordsAPI.NET.Core
{
    public class WordsAPIOptions
    {
        /// <summary>
        /// Default is "https://wordsapiv1.p.rapidapi.com"
        /// </summary>
        public string BaseURL { get; set; } = "https://wordsapiv1.p.rapidapi.com";

        /// <summary>
        /// Default is "wordsapiv1.p.rapidapi.com"
        /// </summary>
        public string RapidAPIHost { get; set; } = "wordsapiv1.p.rapidapi.com";

        /// <summary>
        /// You should use your key here
        /// </summary>
        public string RapidAPIKey { get; set; }
    }
}
