using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlassian.Stash.Entities;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class DefaultReviewerCondition
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("fromRefMatcher")]
        public DefaultReviewerMatcher SourceMatcher { get; set; }
        [JsonProperty("toRefMatcher")]
        public DefaultReviewerMatcher TargetMatcher { get; set; }
        [JsonProperty("requiredApprovals")]
        public int RequiredApprovals { get; set; }
        [JsonProperty("reviewers")]
        public List<User> Reviewers { get; set; }

        public string Name
        {
            get
            {
                var reviews = string.Join(", ", Reviewers.Select(r => r.Name));
                return $"SRC: {SourceMatcher.Id} ({SourceMatcher.Type.Id}), TAR: {TargetMatcher.Id} ({TargetMatcher.Type.Id}), REVIEWERS: ({reviews})";
            }
        }
    }
}
