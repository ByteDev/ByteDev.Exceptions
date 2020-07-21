using System;
using System.Text;

namespace ByteDev.Exceptions
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Exception" />.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a string representation of the exception's message
        /// and all inner exception messages.
        /// </summary>
        /// <param name="source">Exception to perform the operation on.</param>
        /// <returns>String representation of all the exception's messages.</returns>
        public static string AllMessages(this Exception source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var sb = new StringBuilder();
            var index = 0;

            while (source != null)
            {
                if (index > 0)
                {
                    sb.AppendLine();
                    sb.Append(new string('-', index));
                    sb.Append(" ");
                }

                sb.Append(source.Message);

                source = source.InnerException;
                index += 2;
            }

            return sb.ToString();
        }
    }
}