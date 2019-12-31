using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CGAParser;
using Sprache;

namespace CGACompute
{
    /// <summary>
    /// Base class to generate a mesh from a CGA grammar.
    /// </summary>
    public class Compiler
    {
        public Compiler()
        {
        }

        /// <summary>
        /// This method compiles the base context with the incoming grammar.
        /// </summary>
        /// <param name="pGrammar"></param>
        /// <param name="pBaseContext"></param>
        /// <param name="pOutputMesh"></param>
        public void Compile(FileInfo pGrammar, Context pBaseContext, FileInfo pOutputMesh)
        {
            string lValue = File.ReadAllText(pGrammar.FullName);
            lValue = lValue.Replace("\r\n", "\n");
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
