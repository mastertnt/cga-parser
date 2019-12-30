using System.Text;
using Sprache;

namespace CGAParser
{
    /// <summary>
    /// This class represents a real argument of a function.
    /// </summary>
    public class Float : AArgument
    {
        /// <summary>
        /// Parser for fractional part.
        /// </summary>
        public static readonly Parser<string> FRACTIONAL =
            from lDot in Parse.String(".").Text()
            from lDigits in Parse.Digit.Many().Text()
            select lDot + lDigits;

        /// <summary>
        /// Main parser for real.
        /// </summary>
        public static readonly Parser<Float> PARSER =
            from lInteger in Integer.PARSER
            from lFractional in FRACTIONAL.Optional()
            select new Float(lInteger.TypedValue + (lFractional.IsDefined ? lFractional.Get() : ""));

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
        public float TypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The float value.</param>
        public Float(float pValue)
        {
            this.TypedValue = pValue;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The float value as string.</param>
        public Float(string pValue)
        {
            int lIntValue;
            if (int.TryParse(pValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lIntValue))
            {
                this.TypedValue = lIntValue;
            }
            else
            {
                float lValue;
                float.TryParse(pValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lValue);
                this.TypedValue = lValue;
            }
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append(this.TypedValue);
            return lBuilder.ToString();
        }
    }
}

