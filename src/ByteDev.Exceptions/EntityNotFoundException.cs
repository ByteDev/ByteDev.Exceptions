using System;
using System.Runtime.Serialization;

namespace ByteDev.Exceptions
{
    /// <summary>
    /// Represents when an entity does not exist.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; }

        public string EntityId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubb.Apac.Payments.Core.Services.EntityNotFoundException" /> class.
        /// </summary>
        public EntityNotFoundException() : base("Entity does not exist.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubb.Apac.Payments.Core.Services.EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public EntityNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubb.Apac.Payments.Core.Services.EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubb.Apac.Payments.Core.Services.EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="entityType">Entity type.</param>
        public EntityNotFoundException(Type entityType) : this($"Entity does not exist of type: '{entityType.FullName}'.")
        {
            EntityType = entityType;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubb.Apac.Payments.Core.Services.EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="entityType">Entity type.</param>
        /// <param name="entityId">Entity ID.</param>
        public EntityNotFoundException(Type entityType, string entityId) : this($"Entity does not exist of type: '{entityType.FullName}' with ID: '{entityId}'.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubb.Apac.Payments.Core.Services.EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
