using System;
using System.IO;

namespace Activity1
{
    class Program
    {
        static void Main(string[] args)
        {
            AllFiles();
            StreamFile();
        }

        static void AllFiles()
        {
            var lines = File.ReadAllLines("c:\\users\\tlyons\\desktop\\codeacademy\\stage2\\data files\\contacts.csv");

            foreach (var line in lines)
            {
                var splits = line.Split(',');
                Console.WriteLine(splits[1] + " " + splits[2]);
            }
        }

        static void StreamFile()
        {
            using (StreamReader sr = new StreamReader("c:\\users\\tlyons\\desktop\\codeacademy\\stage2\\data files\\contacts.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var splits = line.Split(',');
                    Console.WriteLine(splits[1] + " " + splits[2]);
                }
            }
        }
    }
}
