using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace list_proposal_votes
    {
        public class CondenserApiListProposalVotes : ICondenserApiCall<object, List<CondenserApiProposalVoteModel>>
        {
            public CondenserApiListProposalVotes(CondenserApiProposalVotesStartArrayModel[] start,
                [Range(-1, 1000)] int limit,
                ListProposalOrder order, ListProposalOrderDirection orderDirection,
                ListProposalStatus status)
            {
                var startObjects = new object[start.Length];
                for (var i = 0; i < start.Length; i++)
                    if (string.IsNullOrWhiteSpace(start[i].Voter))
                        startObjects[i] = start[i].Voter;
                    else
                        startObjects[i] = start[i].ProposalId;

                string orderString = null!;
                if (order == ListProposalOrder.ByProposalVoter) orderString = "by_proposal_voter";
                if (order == ListProposalOrder.ByVoterProposal) orderString = "by_voter_proposal";

                string orderDirectionString = null!;
                if (orderDirection == ListProposalOrderDirection.Ascending) orderDirectionString = "ascending";
                if (orderDirection == ListProposalOrderDirection.Descending) orderDirectionString = "descending";

                string statusString = null!;
                if (status == ListProposalStatus.All) statusString = "all";
                if (status == ListProposalStatus.Inactive) statusString = "inactive";
                if (status == ListProposalStatus.Active) statusString = "active";
                if (status == ListProposalStatus.Expired) statusString = "expired";
                if (status == ListProposalStatus.Votable) statusString = "votable";

                QueryParametersJson = new[]
                    {startObjects, (object) limit, orderString, orderDirectionString, statusString};

                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.list_proposal_votes";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiProposalVoteModel>? ExpectedResponseJson { get; }
        }

        public enum ListProposalOrder
        {
            ByVoterProposal,
            ByProposalVoter
        }

        public enum ListProposalOrderDirection
        {
            Ascending,
            Descending
        }

        public enum ListProposalStatus
        {
            All,
            Inactive,
            Active,
            Expired,
            Votable
        }

        public class CondenserApiProposalVotesStartArrayModel
        {
            public CondenserApiProposalVotesStartArrayModel(string voter)
            {
                Voter = voter;
                ProposalId = 0;
            }

            public CondenserApiProposalVotesStartArrayModel(long proposalId)
            {
                Voter = null!;
                ProposalId = proposalId;
            }

            public string Voter { get; }
            public long ProposalId { get; }
        }

        public class CondenserApiProposalVoteModel
        {
            public CondenserApiProposalVoteModel(NumberOrStringModel id, string voter,
                CondenserApiVotedProposalModel condenserApiVotedProposal)
            {
                Id = id;
                Voter = voter;
                CondenserApiVotedProposal = condenserApiVotedProposal;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("voter")] public string Voter { get; }

            [JsonPropertyName("proposal")] public CondenserApiVotedProposalModel CondenserApiVotedProposal { get; }
        }

        public class CondenserApiVotedProposalModel
        {
            public CondenserApiVotedProposalModel(NumberOrStringModel id, NumberOrStringModel proposalId,
                string creator,
                string receiver, DateTime startDate, DateTime endDate, FeeModel dailyPay, string subject,
                string permlink, string totalVotes, string status)
            {
                Id = id;
                ProposalId = proposalId;
                Creator = creator;
                Receiver = receiver;
                StartDate = startDate;
                EndDate = endDate;
                DailyPay = dailyPay;
                Subject = subject;
                Permlink = permlink;
                TotalVotes = totalVotes;
                Status = status;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("proposal_id")] public NumberOrStringModel ProposalId { get; }

            [JsonPropertyName("creator")] public string Creator { get; }

            [JsonPropertyName("receiver")] public string Receiver { get; }

            [JsonPropertyName("start_date")] public DateTime StartDate { get; }

            [JsonPropertyName("end_date")] public DateTime EndDate { get; }

            [JsonPropertyName("daily_pay")] public FeeModel DailyPay { get; }

            [JsonPropertyName("subject")] public string Subject { get; }

            [JsonPropertyName("permlink")] public string Permlink { get; }

            [JsonPropertyName("total_votes")] public string TotalVotes { get; }

            [JsonPropertyName("status")] public string Status { get; }
        }
    }
}