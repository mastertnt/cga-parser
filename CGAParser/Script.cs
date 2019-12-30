using System.Collections.Generic;
using System.Text;
using Sprache;

namespace CGAParser
{
    /// <summary>
    /// A script is a set of functions separated by ";"
    /// </summary>
    public class Script
    {
        /// <summary>
        /// Retrieves a list of functions separated by ";"
        /// </summary>
        public static readonly Parser<IEnumerable<Rule>> RULE_PARSERS = Rule.RULE_PARSER.DelimitedBy(Parse.LineEnd.Token());

        /// <summary>
        /// Main parser.
        /// </summary>
        public static readonly Parser<Script> PARSER =
            from lRules in RULE_PARSERS
            select new Script(lRules);

        /// <summary>
        /// Gets the list of functions.
        /// </summary>
        public IEnumerable<Rule> Rules
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor for a script.
        /// </summary>
        /// <param name="pRules">The list of rules</param>
        public Script(IEnumerable<Rule> pRules)
        {
            this.Rules = pRules;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            foreach (var lRule in this.Rules)
            {
                lBuilder.AppendLine(lRule.ToString());
            }
            return lBuilder.ToString();
        }
    }
}
