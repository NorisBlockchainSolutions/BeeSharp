using BeeSharp.ApiComponents.ApiModels;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode
{
    public class MessageResponseValidator : IMessageResponseValidator
    {
        /// <summary>
        ///     Validate a info message by verifying the Status
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool IsValidInfoMessage(InfoMessageResponseModel response)
        {
            return !string.IsNullOrWhiteSpace(response.Status) &&
                   response.Status == "OK";
        }

        public bool IsValidHardforkVersionMessage(string response)
        {
            return !string.IsNullOrWhiteSpace(response);
        }
    }
}