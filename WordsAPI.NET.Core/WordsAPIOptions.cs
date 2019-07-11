using System;
using System.Collections.Generic;
using System.Text;

namespace WordsAPI.NET.Core
{
    public class WordsAPIOptions
    {
        public string BaseURL { get; set; } = "https://wordsapiv1.p.mashape.com/";
        public string MashapeHost { get; set; } = "wordsapiv1.p.mashape.com";
        public string MashapeKey { get; set; }
    }
}
