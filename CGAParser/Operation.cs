using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprache;

namespace CGAParser
{
    /// <summary>
    /// Abstract class for all operations.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Parser for a list of argument (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<AArgument> ARGUMENT_PARSER = Float.PARSER.Or(Variable.PARSER);

        /// <summary>
        /// Parser for an argument (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<IEnumerable<AArgument>> ARGUMENT_PARSERS = ARGUMENT_PARSER.DelimitedBy(Sprache.Parse.Char(',').Token());

        /// <summary>
        /// Parser for  a function with arguments.
        /// </summary>
        public static readonly Parser<Operation> PARSER_WITH_ARGS =
            from lIdentifier in Common.IDENTIFIER_PARSER
            from lWhiteSpace0 in Common.SPACE.Many()
            from lOpenParenthesis in Sprache.Parse.Char('(')
            from lWhiteSpace1 in Common.SPACE.Many()
            from lArguments in ARGUMENT_PARSERS.Optional()
            from lWhiteSpace2 in Common.SPACE.Many()
            from lCloseParenthesis in Sprache.Parse.Char(')')
            //from lWhiteSpace3 inCommon.SPACE.Many()
            //from lOpenBracket in Sprache.Parse.Char('{').Optional()
            //from lCloseBracket in Sprache.Parse.Char('}').Optional()
            //from lWhiteSpace4 inCommon.SPACE.Many()
            select new Operation(lIdentifier, lArguments.IsDefined ? lArguments.Get() : null);

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
            //lBuilder.AppendLine("==> " +  this.GetType().Name);
            lBuilder.Append(this.Identifier);
            lBuilder.Append("(");
            for (int lIndex = 0; lIndex < this.Arguments.Count(); lIndex++)
            {
                lBuilder.Append(this.Arguments.ElementAt(lIndex));
                if (lIndex != (this.Arguments.Count() - 1))
                {
                    lBuilder.Append(",");
                }
            }
            lBuilder.Append(")");
            return lBuilder.ToString();
        }
    }
}
