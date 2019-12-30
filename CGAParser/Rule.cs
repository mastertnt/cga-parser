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
        public static readonly Parser<Operation> OPERATION_PARSERS = Extrude.PARSER.Or(Operation.PARSER_WITH_ARGS);


        public static readonly Parser<Rule> RULE_PARSER =
            from lPredecessor in Common.IDENTIFIER_PARSER
            from lWhiteSpace1 in Common.SPACE.Many()
            from lSeparator in Sprache.Parse.String("-->")
            from lWhiteSpace2 in Common.SPACE.Many()
            from lOperations in OPERATION_PARSERS
            from lWhiteSpace3 in Common.SPACE.Many()
            from lSuccessor in Common.IDENTIFIER_PARSER.Optional()
            select new Rule(lPredecessor, new List<Operation>() { lOperations }, lSuccessor.IsDefined ? lSuccessor.Get() : "");

        /// <summary>
        /// Gets the identifier of a rule.
        /// </summary>
        public string Identifier
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the successor of a rule.
        /// </summary>
        public string Successor
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
        /// <param name="pOperations">The operations.</param>
        /// /// <param name="pSuccessor">The successor identifier (if any).</param>
        public Rule(string pIdentifier, IEnumerable<Operation> pOperations, string pSuccessor)
        {
            this.Identifier = pIdentifier;
            this.Operations = pOperations;
            this.Successor = pSuccessor;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append(this.Identifier);
            lBuilder.Append("-->");
            foreach (var lOperation in this.Operations)
            {
                lBuilder.Append(lOperation);
                lBuilder.Append(' ');
            }

            if (string.IsNullOrWhiteSpace(this.Successor) == false)
            {
                lBuilder.Append(this.Successor);
            }
            
            return lBuilder.ToString();
        }
    }
}
