namespace CGAParser
{
    /// <summary>
    /// This class represents an argument of a operation.
    /// </summary>
    public abstract class AArgument
    {
        /// <summary>
        /// Gets the value as an object.
        /// </summary>
        public abstract object Value { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected AArgument()
        {
        }
    }
}
