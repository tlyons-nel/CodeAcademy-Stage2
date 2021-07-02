using System;
using System.IO;
using Newtonsoft.Json;

namespace Activity2
{
    class Program
    {
        public class Contact
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
            public Guid Guid { get; set; }
        }


        static void Main(string[] args)
        {
            ReadJson();
        }

        static void ReadJson()
        {
            var text = File.ReadAllText("c:\\users\\tlyons\\desktop\\codeacademy\\stage2\\data files\\contacts.json");
            var contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<Contact[]>(text);

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.IpAddress}");
                Console.WriteLine($"     Skill: {contact.Skill}");
                Console.WriteLine($"     IpAddress: {contact.IpAddress}");
            }
        }

    }
}
