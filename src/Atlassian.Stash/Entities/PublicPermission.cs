using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class PublicPermission
    {
        [JsonProperty("public")]
        public bool Public { get; set; }
    }
}
