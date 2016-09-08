using System;
using System.Collections.Generic;
using System.Text;
using Atlassian.Stash.Entities;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class DefaultReviewerMatcher
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("displayId")]
        public string DisplayId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("type")]
        public DefaultReviewerMatcherType Type { get; set; }
    }
}
