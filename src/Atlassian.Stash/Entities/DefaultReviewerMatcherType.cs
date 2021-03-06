﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class DefaultReviewerMatcherType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
