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
        public static readonly Parser<AArgument> PARSER =
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
                return this.DoubleTypedValue;
            }
        }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        public double? DoubleTypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The boolean value as string.</param>
        public Float(string pValue)
        {
            int lIntValue;
            if (int.TryParse(pValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lIntValue))
            {
                this.DoubleTypedValue = lIntValue;
            }
            else
            {
                double lValue;
                double.TryParse(pValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lValue);
                this.DoubleTypedValue = lValue;
            }
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append(this.DoubleTypedValue);
            return lBuilder.ToString();
        }
    }
}

