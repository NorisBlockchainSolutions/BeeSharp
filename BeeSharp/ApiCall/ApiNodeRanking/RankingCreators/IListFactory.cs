using System.Collections.Generic;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators
{
    public interface IListFactory<T>
    {
        public IList<T> Create();
    }
}