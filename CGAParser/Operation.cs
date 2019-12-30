using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace CGAParser
{
    /// <summary>
    /// Abstract class for all operations.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Parser for an identifier (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<string> IDENTIFIER_PARSER =
            from lFirstLetter in Parse.Letter.Once()
            from lRest in Parse.LetterOrDigit.Many()
            select new string(lFirstLetter.Concat(lRest).ToArray());

        /// <summary>
        /// Parser for a list of argument (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<AArgument> ARGUMENT_PARSER = Float.PARSER;

        /// <summary>
        /// Parser for an argument (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<IEnumerable<AArgument>> ARGUMENT_PARSERS = ARGUMENT_PARSER.DelimitedBy(Sprache.Parse.Char(',').Token());

        /// <summary>
        /// Parser for  a function with arguments.
        /// </summary>
        public static readonly Parser<Operation> PARSER_WITH_ARGS =
            from lIdentifier in IDENTIFIER_PARSER
            from lOpenParenthesis in Sprache.Parse.Char('(')
            from lArguments in ARGUMENT_PARSERS
            from lCloseParenthesis in Sprache.Parse.Char(')')
            select new Operation(lIdentifier, lArguments.ToArray());

        public string Identifier
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of arguments.
        /// </summary>
        public IEnumerable<AArgument> Arguments
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pIdentifier">the idenfiier of the function.</param>
        /// <param name="pArguments">The arguments.</param>
        public Operation(string pIdentifier, IEnumerable<AArgument> pArguments)
        {
            this.Identifier = pIdentifier;
            this.Arguments = pArguments;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append(this.Identifier);
            lBuilder.Append("(");
            foreach (var lArgument in this.Arguments)
            {
                lBuilder.Append(lArgument.ToString());
            }
            lBuilder.Append(")");
            return lBuilder.ToString();
        }
    }
}
