using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprache;

namespace CGAParser
{
    /// <summary>
    /// Rule for all 
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Parser for an identifier (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<string> IDENTIFIER_PARSER =
            from lFirstLetter in Parse.Letter.Once()
            from lRest in Parse.LetterOrDigit.Many()
            select new string(lFirstLetter.Concat(lRest).ToArray());

        public static readonly Parser<IEnumerable<Operation>> OPERATION_PARSERS = Operation.PARSER_WITH_ARGS.DelimitedBy(Sprache.Parse.Char(' ').Token());


        public static readonly Parser<Rule> RULE_PARSER =
            from lPredecessor in IDENTIFIER_PARSER
            from lWhiteSpace1 in Parse.WhiteSpace.Many()
            from lSeparator in Sprache.Parse.String("-->")
            from lWhiteSpace2 in Parse.WhiteSpace.Many()
            from lOperations in OPERATION_PARSERS
            select new Rule(lPredecessor, lOperations);

        /// <summary>
        /// Gets the identifier of a functions.
        /// </summary>
        public string Identifier
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of arguments.
        /// </summary>
        public IEnumerable<Operation> Operations
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor for Rule.
        /// </summary>
        /// <param name="pIdentifier">The rule identifier.</param>
        /// <param name="pBody">The rule body.</param>
        public Rule(string pIdentifier, IEnumerable<Operation> pOperations)
        {
            this.Identifier = pIdentifier;
            this.Operations = pOperations;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append(this.Identifier);
            lBuilder.Append("-->");
            foreach (var lOperation in this.Operations)
            {
                lBuilder.Append(lOperation.ToString());
                lBuilder.Append(' ');
            }
            
            return lBuilder.ToString();
        }
    }
}
