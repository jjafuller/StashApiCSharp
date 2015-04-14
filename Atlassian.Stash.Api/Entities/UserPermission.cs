using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    //paged API https://developer.atlassian.com/static/rest/stash/3.4.0/stash-rest.html#paging-params
    public class UserPermission
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("permission")]
        public string Permission { get; set; }
    }
}