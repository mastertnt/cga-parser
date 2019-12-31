using System.Text;
using Sprache;

namespace CGAParser
{
    class Variable : AArgument
    {
        /// <summary>
        /// Main parser for variable.
        /// </summary>
        public static readonly Parser<AArgument> PARSER =
        from lValue in Common.IDENTIFIER_PARSER
        select new Variable(lValue);

        /// <summary>
        /// Gets the value as an object.
        /// </summary>
        public override object Value
        {
            get
            {
                return this.TypedValue;
            }
        }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        public string TypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The int value.</param>
        public Variable(string pValue)
        {
            this.TypedValue = pValue;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append(this.TypedValue);
            return lBuilder.ToString();
        }
    }
}
