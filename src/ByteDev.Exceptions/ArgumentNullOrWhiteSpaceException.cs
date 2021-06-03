using System;
using System.Runtime.Serialization;

namespace ByteDev.Exceptions
{
    /// <summary>
    /// Represents when a null or whitespace string is passed to a method that does not accept it as a valid argument.
    /// </summary>
    [Serializable]
    public class ArgumentNullOrWhiteSpaceException : ArgumentException
    {
        private const string DefaultMessage = "Value cannot be null or whitespace.";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentNullOrWhiteSpaceException" /> class.
        /// </summary>
        public ArgumentNullOrWhiteSpaceException() : base(DefaultMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentNullOrWhiteSpaceException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public ArgumentNullOrWhiteSpaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentNullOrWhiteSpaceException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public ArgumentNullOrWhiteSpaceException(string paramName) : base(DefaultMessage, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentNullOrWhiteSpaceException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">The message that describes the error.</param>
        public ArgumentNullOrWhiteSpaceException(string paramName, string message) : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentNullOrWhiteSpaceException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected ArgumentNullOrWhiteSpaceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}