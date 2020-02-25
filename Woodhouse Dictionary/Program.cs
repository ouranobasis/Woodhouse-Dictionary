using System;
using System.Xml;
using System.Reflection;
using System.Text;

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
                Assembly assembly = Assembly.GetExecutingAssembly();
                var stream = assembly.GetManifestResourceStream(xmlLocation);             

                using (XmlReader reader = XmlReader.Create(stream))
                {
                    var foundIt = false;

                    while (reader.Read())
                    {                        
                        if (reader.IsStartElement() && reader.Name == "English-Entry" && reader.GetAttribute("id").ToLower() == wordToFind)
                        {
                            Console.Clear();
                            Console.WriteLine($"=============================WORD=================================");
                            Console.WriteLine($"{reader.GetAttribute("id")}");
                            Console.WriteLine("=========================RECOMMENDATIONS===========================");
                            Console.WriteLine($"{GetGreekSuggestions(reader.ReadSubtree())}\n");
                            foundIt = true;
                        }
                    }

                    if (foundIt == false)
                    {                       
                        Console.Clear();
                        Console.WriteLine("=====================THERE ARE NO MATCHES=====================");                      
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
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse A.xml";
                    break;
                case 'b':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse B.xml";
                    break;
                case 'c':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse C.xml";
                    break;
                case 'd':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse D.xml";
                    break;
                case 'e':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse E.xml";
                    break;
                case 'f':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse F.xml";
                    break;
                case 'g':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse G.xml";
                    break;
                case 'h':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse H.xml";
                    break;
                case 'i':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse I.xml";
                    break;
                case 'j':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse J.xml";
                    break;
                case 'k':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse K.xml";
                    break;
                case 'l':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse L.xml";
                    break;
                case 'm':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse M.xml";
                    break;
                case 'n':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse N.xml";
                    break;
                case 'o':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse O.xml";
                    break;
                case 'p':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse P.xml";
                    break;
                case 'q':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse Q.xml";
                    break;
                case 'r':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse R.xml";
                    break;
                case 's':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse S.xml";
                    break;
                case 't':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse T.xml";
                    break;
                case 'u':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse U.xml";
                    break;
                case 'v':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse V.xml";
                    break;
                case 'w':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse W.xml";
                    break;
                case 'y':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse Y.xml";
                    break;
                case 'z':
                    xmlPath = @"WoodhouseDictionary.Woodhouse_XML.Woodhouse Z.xml";
                    break;
            }
            return xmlPath;
        }        
    }
}
