using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    public class CondenserApiContentModel
    {
        public CondenserApiContentModel(string author, string permLink, string category, string title, string body,
            JsonMetadataResponseModel jsonMetadata, DateTime created, DateTime lastUpdate,
            NumberOrStringModel depth, NumberOrStringModel children, DateTime lastPayout, DateTime cashoutTime,
            string totalPayoutValue, string curatorPayoutValue, string pendingPayoutValue, string promoted,
            object[] replies, NumberOrStringModel bodyLength, NumberOrStringModel authorReputation,
            string parentAuthor, string parentPermLink, string url, string rootTitle,
            BeneficiaryModel[] beneficiaries, string maxAcceptedPayout, NumberOrStringModel percentHbd,
            NumberOrStringModel id, DateTime active, NumberOrStringModel authorRewards, DateTime maxCashoutTime,
            NumberOrStringModel rewardWeight, string rootAuthor, string rootPermLink, bool allowReplies,
            bool allowVotes, bool allowCurationRewards, string[] rebloggedBy, NumberOrStringModel netVotes,
            NumberOrStringModel childrenAbsRShares, string totalPendingPayoutValue,
            NumberOrStringModel totalVoteWeight, NumberOrStringModel voteRShares, NumberOrStringModel netRShares,
            NumberOrStringModel absRShares, CondenserApiBlogActiveVoteModel[] activeVotes)
        {
            Author = author;
            PermLink = permLink;
            Category = category;
            Title = title;
            Body = body;
            JsonMetadata = jsonMetadata;
            Created = created;
            LastUpdate = lastUpdate;
            Depth = depth;
            Children = children;
            LastPayout = lastPayout;
            CashoutTime = cashoutTime;
            TotalPayoutValue = totalPayoutValue;
            CuratorPayoutValue = curatorPayoutValue;
            PendingPayoutValue = pendingPayoutValue;
            Promoted = promoted;
            Replies = replies;
            BodyLength = bodyLength;
            AuthorReputation = authorReputation;
            ParentAuthor = parentAuthor;
            ParentPermLink = parentPermLink;
            Url = url;
            RootTitle = rootTitle;
            Beneficiaries = beneficiaries;
            MaxAcceptedPayout = maxAcceptedPayout;
            PercentHbd = percentHbd;
            Id = id;
            Active = active;
            AuthorRewards = authorRewards;
            MaxCashoutTime = maxCashoutTime;
            RewardWeight = rewardWeight;
            RootAuthor = rootAuthor;
            RootPermLink = rootPermLink;
            AllowReplies = allowReplies;
            AllowVotes = allowVotes;
            AllowCurationRewards = allowCurationRewards;
            RebloggedBy = rebloggedBy;
            NetVotes = netVotes;
            ChildrenAbsRShares = childrenAbsRShares;
            TotalPendingPayoutValue = totalPendingPayoutValue;
            TotalVoteWeight = totalVoteWeight;
            VoteRShares = voteRShares;
            NetRShares = netRShares;
            AbsRShares = absRShares;
            ActiveVotes = activeVotes;
        }

        [JsonPropertyName("author")] public string Author { get; }

        [JsonPropertyName("permlink")] public string PermLink { get; }

        [JsonPropertyName("category")] public string Category { get; }

        [JsonPropertyName("title")] public string Title { get; }

        [JsonPropertyName("body")] public string Body { get; }

        [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadata { get; }

        [JsonPropertyName("created")] public DateTime Created { get; }

        [JsonPropertyName("last_update")] public DateTime LastUpdate { get; }

        [JsonPropertyName("depth")] public NumberOrStringModel Depth { get; }

        [JsonPropertyName("children")] public NumberOrStringModel Children { get; }

        [JsonPropertyName("last_payout")] public DateTime LastPayout { get; }

        [JsonPropertyName("cashout_time")] public DateTime CashoutTime { get; }

        [JsonPropertyName("total_payout_value")]
        public string TotalPayoutValue { get; }

        [JsonPropertyName("curator_payout_value")]
        public string CuratorPayoutValue { get; }

        [JsonPropertyName("pending_payout_value")]
        public string PendingPayoutValue { get; }

        [JsonPropertyName("promoted")] public string Promoted { get; }

        [JsonPropertyName("replies")] public object[] Replies { get; }

        [JsonPropertyName("body_length")] public NumberOrStringModel BodyLength { get; }

        [JsonPropertyName("author_reputation")]
        public NumberOrStringModel AuthorReputation { get; }

        [JsonPropertyName("parent_author")] public string ParentAuthor { get; }

        [JsonPropertyName("parent_permlink")] public string ParentPermLink { get; }

        [JsonPropertyName("url")] public string Url { get; }

        [JsonPropertyName("root_title")] public string RootTitle { get; }

        [JsonPropertyName("beneficiaries")] public BeneficiaryModel[] Beneficiaries { get; }

        [JsonPropertyName("max_accepted_payout")]
        public string MaxAcceptedPayout { get; }

        [JsonPropertyName("percent_hbd")] public NumberOrStringModel PercentHbd { get; }

        [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

        [JsonPropertyName("active")] public DateTime Active { get; }

        [JsonPropertyName("author_rewards")] public NumberOrStringModel AuthorRewards { get; }

        [JsonPropertyName("max_cashout_time")] public DateTime MaxCashoutTime { get; }

        [JsonPropertyName("reward_weight")] public NumberOrStringModel RewardWeight { get; }

        [JsonPropertyName("root_author")] public string RootAuthor { get; }

        [JsonPropertyName("root_permlink")] public string RootPermLink { get; }

        [JsonPropertyName("allow_replies")] public bool AllowReplies { get; }

        [JsonPropertyName("allow_votes")] public bool AllowVotes { get; }

        [JsonPropertyName("allow_curation_rewards")]
        public bool AllowCurationRewards { get; }

        [JsonPropertyName("reblogged_by")] public string[] RebloggedBy { get; }

        [JsonPropertyName("net_votes")] public NumberOrStringModel NetVotes { get; }

        [JsonPropertyName("children_abs_rshares")]
        public NumberOrStringModel ChildrenAbsRShares { get; }

        [JsonPropertyName("total_pending_payout_value")]
        public string TotalPendingPayoutValue { get; }

        [JsonPropertyName("total_vote_weight")]
        public NumberOrStringModel TotalVoteWeight { get; }

        [JsonPropertyName("vote_rshares")] public NumberOrStringModel VoteRShares { get; }

        [JsonPropertyName("net_rshares")] public NumberOrStringModel NetRShares { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("abs_rshares")]
        public NumberOrStringModel AbsRShares { get; }

        [JsonPropertyName("active_votes")] public CondenserApiBlogActiveVoteModel[] ActiveVotes { get; }
    }
}