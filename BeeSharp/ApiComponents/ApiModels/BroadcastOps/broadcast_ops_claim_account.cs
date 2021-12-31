using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace claim_account
    {
        [BroadcastOp("claim_account")]
        public class BroadcastOpClaimAccountModel : BroadcastOperation
        {
            /// <summary>
            ///     Claim one or multiple account creation ticket(-s).
            /// </summary>
            /// <param name="fee">The cost of claiming the ticket(-s).</param>
            /// <param name="creator">The account that claims the ticket(-s).</param>
            /// <param name="extensions">Extensions.</param>
            public BroadcastOpClaimAccountModel(string fee, string creator, ExtensionModel[]? extensions = null)
            {
                Fee = fee;
                Creator = creator;
                Extensions = extensions ?? Array.Empty<ExtensionModel>();
            }

            [JsonPropertyName("fee")] public string Fee { get; }

            [JsonPropertyName("creator")] public string Creator { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }
    }
}