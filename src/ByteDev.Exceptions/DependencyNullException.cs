using System;
using System.Runtime.Serialization;

namespace ByteDev.Exceptions
{
    /// <summary>
    /// Represents when a null dependency exists.
    /// </summary>
    [Serializable]
    public class DependencyNullException : Exception
    {
        private const string DefaultMessage = "Dependency cannot be null.";

        /// <summary>
        /// Parameter name.
        /// </summary>
        public virtual string ParamName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.DependencyNullException" /> class.
        /// </summary>
        public DependencyNullException() : base(DefaultMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.DependencyNullException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DependencyNullException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.DependencyNullException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public DependencyNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.DependencyNullException" /> class.
        /// </summary>
        /// <param name="dependencyType">Dependency type.</param>
        public DependencyNullException(Type dependencyType) : base($"Dependency type '{dependencyType?.FullName}' cannot be null.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.DependencyNullException" /> class.
        /// </summary>
        /// <param name="dependencyType">Dependency type.</param>
        /// <param name="paramName">Parameter name.</param>
        public DependencyNullException(Type dependencyType, string paramName) : base($"Dependency type '{dependencyType?.FullName}' cannot be null. (Parameter '{paramName}').")
        {
            ParamName = paramName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.DependencyNullException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected DependencyNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ParamName = (string)info.GetValue(nameof(ParamName), typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(ParamName), ParamName, typeof(string));
        }
    }
}