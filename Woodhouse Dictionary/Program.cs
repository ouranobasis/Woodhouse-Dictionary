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
            using (XmlReader reader = XmlReader.Create(@"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse A.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        Console.WriteLine(reader.Name);
                    }
                }
            }

                Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static void GetDictionarySegment()
        {

        }

        
    }
}
