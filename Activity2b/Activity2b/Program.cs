using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Activity2b
{
    public class Program
    {
        public class ArrayOfContact
        {
            [XmlElement("Contact")]
            public List<Contact> contacts = new List<Contact>();
        }

        public class Contact
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Skill { get; set; }
            public string IpAddress { get; set; }
            public string Guid { get; set; }
        }

        static void Main(string[] args)
        {
            string filepath = "c:\\users\\tlyons\\desktop\\codeacademy\\stage2\\data files\\contacts.xml";

            XmlSerializer deserializer = new XmlSerializer(typeof(ArrayOfContact));
            TextReader reader = new StreamReader(filepath);
            object obj = deserializer.Deserialize(reader);
            ArrayOfContact XMLData = (ArrayOfContact)obj;
            reader.Close();

            for (var i = 0; i < XMLData.contacts.Count; i++)
            {
                Console.WriteLine($"{XMLData.contacts[i].FirstName} {XMLData.contacts[i].LastName}");
                Console.WriteLine($"     Skill: {XMLData.contacts[i].Skill}");
                Console.WriteLine($"     IpAddress: {XMLData.contacts[i].IpAddress}");
            };        
        }

    }
}
