using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;
using BeeSharp.ApiCall.ApiWebCalls;
using BeeSharp.ApiCall.ApiWebCalls.WebClient;
using BeeSharp.ApiComponents.ApiModels;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_hardfork_version;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode
{
    public class ApiNodePerformanceTester : IApiNodePerformanceTester
    {
        private readonly ICollisionFreeEntryAdder<string> _collisionFreeEntryAdder;
        private readonly IMessageResponseValidator _messageResponseValidator;
        private readonly IWebClientAdapter _webClientAdapter;
        private readonly IWebClientFactory _webClientFactory;

        public ApiNodePerformanceTester(IWebClientAdapter webClientAdapter, IWebClientFactory webClientFactory,
            ICollisionFreeEntryAdder<string> collisionFreeEntryAdder,
            IMessageResponseValidator messageResponseValidator)
        {
            _webClientAdapter = webClientAdapter;
            _webClientFactory = webClientFactory;
            _collisionFreeEntryAdder = collisionFreeEntryAdder;
            _messageResponseValidator = messageResponseValidator;
        }

        /// <summary>
        ///     Measure the performance of a single apiNode connection.
        ///     Adds the node to the list of tested apiNodes, if successful.
        /// </summary>
        /// <param name="urlList">The benchmarked list of apiNode urls.</param>
        /// <param name="nodeUrl">The url of the apiNode to check.</param>
        /// <param name="timeout">The webClient timeout.</param>
        /// <returns>The elapsed time in ms, or -1 if an error occurred.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is invalid.</exception>
        /// <exception cref="TimeoutException">Thrown when the request timed out.</exception>
        public async Task TestNodePerformanceAsync(ISortedIDictionary<long, string> urlList, string nodeUrl,
            ushort timeout)
        {
            try
            {
                var client = _webClientFactory.Create(nodeUrl, timeout);
                var webCall = new WebClientCall(client);

                // Measure response time
                var sw = new Stopwatch();
                sw.Start();
                var model = new CondenserApiGetHardforkVersion();
                var response = await _webClientAdapter.PostApiCallAsync(webCall,
                    new HiveApiCallModel<object>(model.MethodName, model.QueryParametersJson));
                sw.Stop();

                if (_messageResponseValidator.IsValidHardforkVersionMessage(response))
                {
                    var timedUrl = new EntryToAdd<long, string>(urlList, sw.ElapsedMilliseconds, nodeUrl);
                    await _collisionFreeEntryAdder.AddEntryThreadSafeAsync(timedUrl);
                }
                else
                {
                    // Check failed
                    throw new TaskCanceledException("Response message check failed!");
                }
            }
            catch (TaskCanceledException e)
            {
                // process inner exception
                if (e.InnerException is TimeoutException)
                    // request timeout
                    throw e.InnerException;
                throw;
            }
        }
    }
}