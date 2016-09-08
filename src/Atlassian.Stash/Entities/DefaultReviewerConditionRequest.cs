using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlassian.Stash.Entities;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class DefaultReviewConditionRequest
    {
        [JsonProperty("sourceMatcher")]
        public DefaultReviewerMatcher SourceMatcher { get; set; }
        [JsonProperty("targetMatcher")]
        public DefaultReviewerMatcher TargetMatcher { get; set; }
        [JsonProperty("requiredApprovals")]
        public int RequiredApprovals { get; set; }
        [JsonProperty("reviewers")]
        public List<User> Reviewers { get; set; }
    }
}
