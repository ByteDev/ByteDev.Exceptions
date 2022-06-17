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
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
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

        /// <summary>
        /// Searchs the inner exception hierarchy of the exception for the first exception
        /// with the matching type. If no match can be found then null is returned.
        /// </summary>
        /// <typeparam name="TException">Exception type to search for.</typeparam>
        /// <param name="source">Exception to perform the operation on.</param>
        /// <returns>First exception that matches type; otherwise null.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static Exception FindInner<TException>(this Exception source) where TException : Exception
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            var innerException = source.InnerException;

            while (innerException != null)
            {
                if (innerException.GetType() == typeof(TException))
                    return innerException;

                innerException = innerException.InnerException;
            }

            return null;
        }
    }
}