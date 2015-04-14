using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    //paged API https://developer.atlassian.com/static/rest/stash/3.4.0/stash-rest.html#paging-params
    public class User
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public Link Link { get; set; }
        public Links Links { get; set; }
    }
}