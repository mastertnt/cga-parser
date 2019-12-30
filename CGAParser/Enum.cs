using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAParser
{
    public class Enumeration<TEnumType> : AArgument
    {
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
        public TEnumType TypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The int value.</param>
        public Enumeration(TEnumType pValue)
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
