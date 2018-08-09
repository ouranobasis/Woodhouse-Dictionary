using System;
using System.Xml;
using System.Linq;
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
            string xmlLocation;

            while (true)
            {
                Console.WriteLine("Enter word:");
                string wordToFind = Console.ReadLine().ToString().ToLower();
                xmlLocation = GetDictionarySegmentFile(wordToFind);

                using (XmlReader reader = XmlReader.Create(xmlLocation))
                {
                    while (reader.Read())
                    {                        
                        if (reader.IsStartElement() && reader.Name == "English-Entry" && reader.GetAttribute("id").ToLower() == wordToFind)
                        {
                            Console.WriteLine($"=============================WORD=================================");
                            Console.WriteLine($"{reader.GetAttribute("id")}");
                            Console.WriteLine("=========================RECOMMENDATIONS===========================");
                            Console.WriteLine($"{GetGreekSuggestions(reader.ReadSubtree())}\n");
                        }
                    }
                }
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

        static string GetDictionarySegmentFile(string word)
        {
            word = word.ToString().ToLower();
            var firstLetter = word[0];

            var xmlPath = "";
            switch (firstLetter)
            {
                case 'a':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse A.xml";
                    break;
                case 'b':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse B.xml";
                    break;
                case 'c':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse C.xml";
                    break;
                case 'd':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse D.xml";
                    break;
                case 'e':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse E.xml";
                    break;
                case 'f':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse F.xml";
                    break;
                case 'g':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse G.xml";
                    break;
                case 'h':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse H.xml";
                    break;
                case 'i':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse I.xml";
                    break;
                case 'j':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse J.xml";
                    break;
                case 'k':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse K.xml";
                    break;
                case 'l':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse L.xml";
                    break;
                case 'm':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse M.xml";
                    break;
                case 'n':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse N.xml";
                    break;
                case 'o':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse O.xml";
                    break;
                case 'p':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse P.xml";
                    break;
                case 'q':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse Q.xml";
                    break;
                case 'r':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse R.xml";
                    break;
                case 's':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse S.xml";
                    break;
                case 't':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse T.xml";
                    break;
                case 'u':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse U.xml";
                    break;
                case 'v':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse V.xml";
                    break;
                case 'w':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse W.xml";
                    break;
                case 'y':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse Y.xml";
                    break;
                case 'z':
                    xmlPath = @"C:\Users\jpruitt\Source\Repos\Woodhouse-Dictionary\Woodhouse Dictionary\Woodhouse XML\Woodhouse Z.xml";
                    break;
            }
            return xmlPath;
        }        
    }
}
