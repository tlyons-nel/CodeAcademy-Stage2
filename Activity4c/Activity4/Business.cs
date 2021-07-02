using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;

namespace Activity4
{
    class Business
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("name")]
        public string Name { get; set; }

        public List<Contact> Contacts { get; private set; } = new List<Contact>();
    }
}
