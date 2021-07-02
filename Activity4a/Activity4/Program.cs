using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Linq;

namespace Activity4
{
    class Program
    {
        static void Main(string[] args)
        {
            var businesses = ReadBusiness();
            var contacts = ReadContacts();
            var links = ReadLinks();

            foreach (var business in businesses)
            {
                Console.WriteLine($"{business.Name}");
                Console.WriteLine(business.Id.GetType());
                Console.WriteLine("here");
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            }

            foreach (var link in links)
            {
                Console.WriteLine($"{link.BusinessId} {link.ContactId}");
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
