using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Linq;
using System.Collections.Generic;

namespace Activity4
{
    class Program
    {
        static void Main(string[] args)
        {
            var businesses = ReadBusiness();
            var contacts = ReadContacts();
            var links = ReadLinks();

            foreach (var link in links)
            {
                var business = businesses.Where(b => b.Id == link.BusinessId).FirstOrDefault();
                int businessIndex = Array.IndexOf(businesses, business);

                var contact = contacts.Where(c => c.Id == link.ContactId).FirstOrDefault();

                businesses[businessIndex].Contacts.Add(contact);
            }

            Console.WriteLine("Businesses with one or more Contacts: ");
            foreach (var business in businesses)
            {
                if (business.Contacts.Count > 0)
                {
                    Console.WriteLine(business.Id + " " + business.Contacts[0].LastName);
                }
            }

            Console.WriteLine("Businesses with 50 or more Contacts: ");
            foreach (var business in businesses)
            {
                if (business.Contacts.Count > 49)
                {
                    Console.WriteLine(business.Id + " " + business.Contacts[0].LastName);
                }
            }
        }

        static Contact[] ReadContacts()
        {
            using var reader = new StreamReader("Contacts.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var contacts = csv.GetRecords<Contact>().ToArray();
            return contacts;
        }

        static Business[] ReadBusiness()
        {
            using var reader = new StreamReader("Business.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var businesses = csv.GetRecords<Business>().ToArray();
            return businesses;
        }

        static ContactToBusinessLink[] ReadLinks()
        {
            using var reader = new StreamReader("ContactToBusiness.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var links = csv.GetRecords<ContactToBusinessLink>().ToArray();
            return links;
        }
    }
}
