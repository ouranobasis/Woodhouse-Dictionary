using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodhouseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;



            string xmlLocation = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse E.xml";

            while (true)
            {
                Console.WriteLine("Enter word:");
                string wordToFind = Console.ReadLine().ToString();
                using (XmlReader reader = XmlReader.Create(xmlLocation))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && reader.Name == "English-Entry" && reader.GetAttribute("id") == wordToFind)
                        {
                            Console.WriteLine(reader.GetAttribute("id"));
                            Console.WriteLine("=========================RECOMMENDATIONS===========================");
                            Console.WriteLine($"{GetGreekSuggestions(reader.ReadSubtree())}\n");
                        }
                    }
                }
                Console.ReadKey();
            }
        }

        static string GetGreekSuggestions(XmlReader wordReader)
        {
            string word = "";
            while (wordReader.Read())
            {
                if (wordReader.IsStartElement() && wordReader.Name == "Greek-Entry")
                {
                    wordReader.Read();
                    word = wordReader.Value.Trim();
                }
            }
            return word;
        }

        static void GetDictionarySegmentFile()
        {

        }

        
    }
}
