using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace CGAParser.TestApp
{
    class Program
    {
        static void Main(string[] pArgs)
        {
            string lValue = File.ReadAllText("SampleFile.txt");
            lValue = lValue.Replace("\r\n", "\n");
            // lValue = "Lot  --> extrude(10) Envelope\nEnvelope --> split(y)";
            Console.WriteLine(lValue);
            var lParseResult = Script.PARSER.TryParse(lValue);
            if (lParseResult.WasSuccessful)
            {
                Console.WriteLine(lParseResult.Value);
            }
            else
            {
                Console.WriteLine(lParseResult.Message);
            }
        }
    }
}
