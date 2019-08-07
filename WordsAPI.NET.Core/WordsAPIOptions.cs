using System;
using System.Collections.Generic;
using System.Text;

namespace WordsAPI.NET.Core
{
    public class WordsAPIOptions
    {
        /// <summary>
        /// Default is "https://wordsapiv1.p.mashape.com/"
        /// </summary>
        public string BaseURL { get; set; } = "https://wordsapiv1.p.mashape.com/";

        /// <summary>
        /// Default is "wordsapiv1.p.mashape.com"
        /// </summary>
        public string MashapeHost { get; set; } = "wordsapiv1.p.mashape.com";

        /// <summary>
        /// You should use your key here
        /// </summary>
        public string MashapeKey { get; set; }
    }
}
