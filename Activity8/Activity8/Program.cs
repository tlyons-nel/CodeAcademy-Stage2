using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CsvHelper;

namespace Activity8
{
    static class Program
    {
        public static IConfigurationRoot _configuration
        {
            get;
            private set;
        }
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, configuration) =>
        {
            configuration.Sources.Clear();
            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configurationRoot = configuration.Build();
            _configuration = configurationRoot;
        }).ConfigureServices((services) =>
        {
            services.AddHostedService<ConsoleService>();
        });

        static Contact[] ReadContacts()
        {
            using var reader = new StreamReader("Contacts.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var contacts = csv.GetRecords<Contact>().ToArray();
            return contacts;
        }
    }

}
