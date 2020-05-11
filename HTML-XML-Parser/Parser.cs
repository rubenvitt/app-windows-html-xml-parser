using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HTML_XML_Parser
{
    public class Parser
    {
        public static string EingabePfad { get { return @"A:\html.xml"; } }
        public static string AusgabePfad { get { return @"A:\ausgabe.xml"; } }
        internal static void MakeXmlFile()
        {
            List<Lied> Lieder = new List<Lied>();
            ReadFromXMLFile(ref Lieder);

            XmlSerializer s = new XmlSerializer(typeof(List<Lied>));
            TextWriter w = new StreamWriter(AusgabePfad);
            s.Serialize(w, Lieder);
            w.Close();
        }

        internal static void ReadFromXMLFile(ref List<Lied> Lieder)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(EingabePfad);
                foreach (XmlNode node in doc.GetElementsByTagName("tr"))
                {
                    Lied newEntry = new Lied();
                    int counter = 0;
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (counter == 0)
                            newEntry.titel = childNode.InnerText;
                        if (counter == 1)
                            newEntry.interpret = childNode.InnerText;
                        if (counter == 2)
                            newEntry.album = childNode.InnerText;
                        counter++;
                    }
                    Lieder.Add(newEntry);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message} + \r\n {ex.StackTrace}");
                throw new Exception("Ausnahme im Parsen", ex);                
            }
        }
    }

    [Serializable]
    public class Lied
    {
        public string titel;
        public string interpret;
        public string album;
    }
}
