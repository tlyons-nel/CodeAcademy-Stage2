using System;
using CsvHelper.Configuration.Attributes;
using System.Linq;

namespace Activity5
{
    class Contact
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("first_name")]
        public string FirstName { get; set; }
        [Name("last_name")]
        public string LastName { get; set; }
        [Name("email")]
        public string Email { get; set; }
        [Name("gender")]
        public string Gender { get; set; }
        [Name("skill")]
        public string Skill { get; set; }
        [Name("ip_address")]
        public string IpAddress { get; set; }
        [Name("GUID")]
        public Guid GUID { get; set; }
    }

    /*
    public static Business[] Businesses(this Contact contact, Business[] businesses)
    {
        return businesses.Where(b => b.Contacts.Any(c => c.Id == contact.Id)).ToArray();
    }
    */
}
