using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Linq;
using System.Collections.Generic;

namespace Activity5
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

            Console.WriteLine($"Businesses with one or more Contacts: {businesses.Count(b => b.Contacts.Count() > 0)}");
            foreach (var business in businesses)
            {
                if (business.Contacts.Count > 0)
                {
                    Console.WriteLine($"ID: {business.Id,5}  Name:{business.Name, -25}  Number of Contacts: {business.Contacts.Count()}");
                }
            }

            Console.WriteLine($"\nBusinesses with 50 or more Contacts: {businesses.Count(b => b.Contacts.Count() > 49)}");
            foreach (var business in businesses)
            {
                if (business.Contacts.Count > 49)
                {
                    Console.WriteLine($"ID: {business.Id,5}  Name:{business.Name, -25}  Number of Contacts: {business.Contacts.Count()}");
                }
            }

            //***************************************************************************************************************************
            Console.WriteLine("\nActivity 5 - Print Contacts associated with Edgepulse");
            var edgePulse = businesses.First(b => b.Name.ToLower() == "Edgepulse".ToLower());
            PrintContacts(edgePulse.Contacts);

            Console.WriteLine("\nActivity 5 - Print Businesses associated with Gabie Boulder");
            var contact1 = contacts.Where(c => c.FirstName == "Gabie" && c.LastName == "Boulder").FirstOrDefault();
            var businessList1 = links.Where(l => l.ContactId == contact1.Id).Select(l => l.BusinessId ).Distinct();
            //var businessList = (from b in businesses
            //            from c in b.Contacts
            //            where c.FirstName == "Gabie" && c.LastName == "Boulder"
            //            select new { Id = b.Id, Name = b.Name }).Distinct();

            
            foreach (var id in businessList1)
            {
                Console.WriteLine($"ID: {id,5}  Name: {businesses.Where(b => b.Id == id).FirstOrDefault().Name}");
            }

            //***************************************************************************************************************************
            Console.WriteLine("\nActivity 5 - Which Contact is associated with most businesses");
            Dictionary<Contact, int> businessCount = new Dictionary<Contact, int>();
            foreach (var contact in contacts)
            {
                var count = ((from b in businesses
                                      from c in b.Contacts
                                      where c.FirstName == contact.FirstName && c.LastName == contact.LastName
                                      select b.Id).Distinct()).Count();

                businessCount.Add(contact, count);
            }
            
            var maxCount = businessCount.Max(c => c.Value);

            foreach (KeyValuePair<Contact, int> kvp in businessCount)
            {
                if (kvp.Value == maxCount)
                {
                    Console.WriteLine($"{kvp.Key.Id} : {kvp.Key.FirstName} {kvp.Key.LastName} : Business Count = {kvp.Value}");
                } 
            }

            var mostUsedId = links.GroupBy(c => c.ContactId).OrderBy(b => b.Count()).Last().Key;
            var mostUsedName = contacts.Where(c => c.Id == mostUsedId).Select(s => new { First = s.FirstName, Last = s.LastName }).FirstOrDefault();
            Console.WriteLine($"User associated with the most businesses: ID: {mostUsedId}  {mostUsedName.First} {mostUsedName.Last} ");
            
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

        static void PrintContacts(List<Contact> contacts)
        {
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }
        
    }
}

