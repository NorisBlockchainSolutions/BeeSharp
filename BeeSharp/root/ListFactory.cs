using System.Collections.Generic;
using BeeSharp.ApiCall.ApiNodeRanking.RankingCreators;

namespace BeeSharp.root
{
    public class ListFactory<T> : IListFactory<T>
    {
        public IList<T> Create()
        {
            return new List<T>();
        }
    }
}