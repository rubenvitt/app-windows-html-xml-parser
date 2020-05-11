using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HTML_XML_Parser
{
    class Test
    {
        void Run()
        {
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.Black;
            WriteLine($"Bitte stellen Sie sicher, dass die Eingabedatei unter \"{Parser.EingabePfad}\" liegt.\nDie Datei wird nach {Parser.AusgabePfad} exportiert.");
            WriteLine("Bitte eine Taste drücken...");
            ReadKey();
            Parser.MakeXmlFile();
            WriteLine("Fertig!");
        }

        static void Main(string[] args)
        {
            new Test().Run();
            ReadKey();
        }
    }
}
