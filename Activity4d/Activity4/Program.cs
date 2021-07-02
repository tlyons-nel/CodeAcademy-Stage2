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

            foreach (KeyValuePair<int, ContactToBusinessLink> kvp in links)
            {
                Contact contact = contacts[kvp.Value.ContactId];
                businesses[kvp.Value.BusinessId].Contacts.Add(contact);
            }

            Console.WriteLine($"Businesses with one or more Contacts: {businesses.Count(b => b.Value.Contacts.Count > 0)}");
            foreach (KeyValuePair<int, Business> business in businesses)
            {
                if (business.Value.Contacts.Count > 0)
                {
                    Console.WriteLine($"ID: {business.Value.Id}  Name: {business.Value.Name}  Number of Contacts: {business.Value.Contacts.Count()}");
                }
            }

            Console.WriteLine($"\nBusinesses with 50 or more Contacts: {businesses.Count(b => b.Value.Contacts.Count > 49)}");
            foreach (KeyValuePair<int, Business> business in businesses)
            {
                if (business.Value.Contacts.Count > 49)
                {
                    Console.WriteLine($"ID: {business.Value.Id}  Name: {business.Value.Name}  Number of Contacts: {business.Value.Contacts.Count()}");
                }
            }
        }

        static Dictionary<int, Contact> ReadContacts()
        {
            using var reader = new StreamReader("Contacts.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            /* Version 1
            var contacts = csv.GetRecords<Contact>().ToArray();
            Dictionary<int, Contact> contactDict = new Dictionary<int, Contact>();
            foreach (var contact in contacts)
            {
                contactDict.Add(contact.Id, contact);
            }
            */

            Dictionary<int, Contact> contactDict = csv.GetRecords<Contact>().ToDictionary(x => x.Id);
            return contactDict;
        }

        static Dictionary<int, Business> ReadBusiness()
        {
            using var reader = new StreamReader("Business.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            /* Version 1
            var businesses = csv.GetRecords<Business>().ToArray();
            Dictionary<int, Business> businessDict = new Dictionary<int, Business>();
            foreach (var business in businesses)
            {
                businessDict.Add(business.Id, business);
            }
            */

            Dictionary<int, Business> businessDict = csv.GetRecords<Business>().ToDictionary(x => x.Id);
            return businessDict;
        }

        static Dictionary<int, ContactToBusinessLink> ReadLinks()
        {
            int i = 0;
            using var reader = new StreamReader("ContactToBusiness.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            /* Version 1
            var links = csv.GetRecords<ContactToBusinessLink>().ToArray();
            Dictionary<int, ContactToBusinessLink> linkDict = new Dictionary<int, ContactToBusinessLink>();
            foreach (var link in links)
            {
                linkDict.Add(i, link);
                i++;
            }
            */

            Dictionary<int, ContactToBusinessLink> linkDict = csv.GetRecords<ContactToBusinessLink>().ToDictionary(x => i++);
            return linkDict;
        }
    }
}
