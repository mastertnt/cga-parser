using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CGACompute;
using Sprache;

namespace CGAParser.TestApp
{
    class Program
    {
        static void Main(string[] pArgs)
        {
            if (pArgs.Length == 2 && pArgs[0] == "compute")
            {
                Compiler lCompiler = new Compiler();
                lCompiler.Compile(new FileInfo(pArgs[1]), new Context(), new FileInfo(""));
            }
            else if (pArgs.Length == 1)
            {
                Console.WriteLine("Try parse on " + pArgs[0]);
                Compiler lCompiler = new Compiler();
                lCompiler.Compile(new FileInfo(pArgs[0]), new Context(), new FileInfo(""));
            }
            else if (pArgs.Length == 1)
            {
                Console.WriteLine("Try parse on SampleFile.txt");
                Compiler lCompiler = new Compiler();
                lCompiler.Compile(new FileInfo("SampleFile.txt"), new Context(), new FileInfo(""));
            }
        }
    }
}
