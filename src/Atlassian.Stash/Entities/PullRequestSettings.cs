using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class PullRequestSettings
    {
        [JsonProperty("requiredApprovers")]
        public int RequiredApprovers { get; set; }
        [JsonProperty("requiredAllTasksComplete")]
        public bool RequiredAllTasksComplete { get; set; }
        [JsonProperty("requiredSuccessfulBuilds")]
        public int RequiredSuccessfulBuilds { get; set; }
    }
}
