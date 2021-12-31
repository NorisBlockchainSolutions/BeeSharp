using System;
using BeeSharp.ApiCall.ApiUrlForSingleRequest;

namespace BeeSharp.root
{
    public class RandomProvider : IRandomProvider
    {
        public Random Rnd { get; } = new();
    }
}