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
            var lParseResult = Script.PARSER.TryParse(File.ReadAllText("SampleFile.txt"));
            if (lParseResult.WasSuccessful)
            {
                Console.WriteLine(lParseResult);
            }
            else
            {
                Console.WriteLine(lParseResult.Message);
            }
        }
    }
}
