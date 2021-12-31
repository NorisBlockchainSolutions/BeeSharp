using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.list_proposal_votes;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace list_proposals
    {
        public class CondenserApiListProposals : ICondenserApiCall<object, List<CondenserApiProposalModel>>
        {
            public CondenserApiListProposals(CondenserApiListProposalsStartArrayModel[] start,
                [Range(-1, 1000)] int limit,
                ListProposalsOrder order, ListProposalOrderDirection orderDirection,
                ListProposalStatus status)
            {
                var startObjects = new object[start.Length];
                for (var i = 0; i < start.Length; i++)
                    if (start[i].Creator is not null)
                        startObjects[i] = start[i].Creator!;
                    else if (start[i].StartDate is not null)
                        startObjects[i] = start[i].StartDate!;
                    else if (start[i].EndDate is not null)
                        startObjects[i] = start[i].EndDate!;
                    else
                        startObjects[i] = start[i].TotalVotes!;

                string orderString = null!;
                if (order == ListProposalsOrder.ByCreator) orderString = "by_creator";
                if (order == ListProposalsOrder.ByStartDate) orderString = "by_start_date";
                if (order == ListProposalsOrder.ByEndDate) orderString = "by_end_date";
                if (order == ListProposalsOrder.ByTotalVotes) orderString = "by_total_votes";

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

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.list_proposals";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiProposalModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiListProposalsStartArrayModel
        {
            public CondenserApiListProposalsStartArrayModel(string? creator = null,
                DateTime? startDate = null, DateTime? endDate = null,
                int? totalVotes = null)
            {
                Creator = creator;
                StartDate = startDate;
                EndDate = endDate;
                TotalVotes = totalVotes;
            }

            public string? Creator { get; }

            public DateTime? StartDate { get; }

            public DateTime? EndDate { get; }

            public int? TotalVotes { get; }
        }

        public enum ListProposalsOrder
        {
            ByCreator,
            ByStartDate,
            ByEndDate,
            ByTotalVotes
        }
    }
}