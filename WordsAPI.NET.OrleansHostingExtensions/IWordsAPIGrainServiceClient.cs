using Orleans.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordsAPI.NET.OrleansHostingExtensions
{
    public interface IWordsAPIGrainServiceClient : IGrainServiceClient<IWordsAPIGrainService>, IWordsAPIGrainService
    {
    }
}
