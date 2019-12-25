using NLP.API.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordsAPI.NET.Core.Types
{
	public class Everything
	{
		public string Word { get; set; }
		public List<Result> Results { get; set; }
		public Syllables Syllables { get; set; }
		public Pronunciation Pronunciation { get; set; }
		public double Frequency { get; set; }
	}

	public class Result
	{
		public string Definition { get; set; }
		public PartOfSpeech? PartOfSpeech { get; set; }
		public List<string> Synonyms { get; set; }
		public List<string> TypeOf { get; set; }
		public List<string> HasTypes { get; set; }
		public List<string> Derivation { get; set; }
		public List<string> Examples { get; set; }
	}

	public class Syllables
	{
		public int Count { get; set; }
		public List<string> List { get; set; }
	}

	public class Pronunciation
	{
		public static implicit operator Pronunciation(string all) => new Pronunciation() { All = all };
		public string All { get; set; }
	}
}
