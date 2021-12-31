using BeeSharp.ApiComponents.ApiModels;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode
{
    public interface IMessageResponseValidator
    {
        /// <summary>
        ///     Validate a info message by verifying the Status
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool IsValidInfoMessage(InfoMessageResponseModel response);

        /// <summary>
        ///     Validate a hardfork version message by verifying the response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool IsValidHardforkVersionMessage(string response);
    }
}