using Sprache;

namespace CGAParser
{
    class Integer : AArgument
    {
        /// <summary>
        /// Main parser for integer.
        /// </summary>
        public static readonly Parser<Integer> PARSER =
            from minus in Sprache.Parse.String("-").Text().Optional()
            from digits in Sprache.Parse.Digit.Many().Text()
            select new Integer((minus.IsDefined ? minus.Get() : "") + digits);


        /// <summary>
        /// Gets the value as an object.
        /// </summary>
        public override object Value
        {
            get { return this.TypedValue; }
        }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        public int TypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The int value.</param>
        public Integer(int pValue)
        {
            this.TypedValue = pValue;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The integer as string.</param>
        public Integer(string pValue)
        {
            int lValue;
            int.TryParse(pValue, out lValue);
            this.TypedValue = lValue;
        }
    }
}
