using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Activity3
{
    class Program
    {
        static void Main(string[] args)
        {
            Activity3a();
            Activity3b();
            Activity3c();
            Activity3d();
            Activity3e();
        }

        static void Activity3a()
        {
            var text = File.ReadAllText("contactswithheight.json");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);

            Console.WriteLine("Contacts list (foreach loop): ");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} Height={contact.Height}");
            }
        }

        static void Activity3b()
        {
            var text = File.ReadAllText("contactswithheight.json");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            var i = 0;


            Console.WriteLine("\nContacts list (while loop): ");
            while (i < contacts.Length)
            {
                Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} Height={contacts[i].Height}");
                i++;
            }
        }

        static void Activity3c()
        {
            var text = File.ReadAllText("contactswithheight.json");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            var i = 0;

            Console.WriteLine("\nContacts list (do-while loop): ");
            do
            {
                Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} Height={contacts[i].Height}");
                i++;
            } while (i < contacts.Length);
        }

        static void Activity3d()
        {
            var text = File.ReadAllText("contactswithheight.json");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            var i = 0;

            Console.WriteLine("\nContacts with height over 70 (do-while loop): ");
            do
            {
                if (contacts[i].Height > 70)
                {
                    Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} Height={contacts[i].Height}");
                }
                i++;
            } while (i < contacts.Length);
        }

        static void Activity3e()
        {
            var text = File.ReadAllText("contactswithheight.json");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);

            Console.WriteLine("\nContacts with height under 68 (Linq query): ");
            var contactsList = contacts.Where(c => c.Height < 68);
            foreach (var contact in contactsList)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} Height={contact.Height}");
            }
        }
    }
}
