using System;
using System.Collections.Generic;
using System.IO;
using CGACompute.Factories;
using CGAParser;
using Newtonsoft.Json;
using Sprache;

namespace CGACompute
{
    /// <summary>
    /// Base class to generate a mesh from a CGA grammar.
    /// </summary>
    public class Compiler
    {
        public Dictionary<Type, IAlgorithmFactory> mAlgorithms = new Dictionary<Type, IAlgorithmFactory>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Compiler()
        {
            this.mAlgorithms.Add(typeof(CGAParser.Extrude), new ExtrudeFactory());
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
                int lIndex = 0;
                foreach (Rule lRule in lParseResult.Value.Rules)
                {
                    Console.WriteLine("Try to apply rule : " + lRule);
                    foreach (Operation lOperation in lRule.Operations)
                    {
                        IAlgorithmFactory lAlgorithmType;
                        if (this.mAlgorithms.TryGetValue(lOperation.GetType(), out lAlgorithmType))
                        {
                            Console.WriteLine("Run algorithm");
                            IGenericAlgorithm lAlgorithm = lAlgorithmType.Create(lOperation);
                            Shape lResultShape = lAlgorithm.Compute(pBaseContext.GetVariable(lRule.Identifier));
                            if (string.IsNullOrWhiteSpace(lRule.Successor) == false)
                            {
                                pBaseContext.SetVariable(lRule.Successor, lResultShape);
                                string lJson = JsonConvert.SerializeObject(lResultShape);
                                File.WriteAllText(lAlgorithm.GetType().Name + "_" + lIndex + "_result.json", lJson);
                                lIndex++;
                            }
                        }
                    }
                    
                }
            }
            else
            {
                Console.WriteLine(lParseResult.Message);
            }
        }
    }
}
