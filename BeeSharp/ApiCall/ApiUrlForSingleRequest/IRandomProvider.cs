using System;

namespace BeeSharp.ApiCall.ApiUrlForSingleRequest
{
    public interface IRandomProvider
    {
        public Random Rnd { get; }
    }
}