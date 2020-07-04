using System;
using System.Runtime.Serialization;

namespace ByteDev.Exceptions
{
    /// <summary>
    /// Represents when a default value is passed to a method that does not accept it as a valid argument.
    /// </summary>
    [Serializable]
    public class ArgumentDefaultException : ArgumentException
    {
        private const string DefaultMessage = "Value cannot be default.";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentDefaultException" /> class.
        /// </summary>
        public ArgumentDefaultException() : base(DefaultMessage)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentDefaultException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public ArgumentDefaultException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentDefaultException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public ArgumentDefaultException(string paramName) : base(DefaultMessage, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentDefaultException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">The message that describes the error.</param>
        public ArgumentDefaultException(string paramName, string message) : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ArgumentDefaultException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected ArgumentDefaultException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}