using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Activity3
{
    class Contact
    {
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        [JsonProperty("skill")]
        public string Skill { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
