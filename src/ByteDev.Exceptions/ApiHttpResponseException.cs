using System;
using System.Net;
using System.Runtime.Serialization;

namespace ByteDev.Exceptions
{
    /// <summary>
    /// Represents an HTTP based API response exception.  
    /// </summary>
    [Serializable]
    public class ApiHttpResponseException : Exception
    {
        /// <summary>
        /// HTTP response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// HTTP response content as a string.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        public ApiHttpResponseException() : base("Error occurred from API response.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApiHttpResponseException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public ApiHttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">Response HTTP status code.</param>
        public ApiHttpResponseException(string message, HttpStatusCode statusCode) 
            : this(message, statusCode, null as Exception)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">Response HTTP status code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ApiHttpResponseException(string message, HttpStatusCode statusCode, Exception innerException)
            : base($"{message.Trim().EnsureEndsWith(".")} Status code: '{statusCode.ToReadableString()}'.", innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">Response HTTP status code.</param>
        /// <param name="content">Response content as a string.</param>
        public ApiHttpResponseException(string message, HttpStatusCode statusCode, string content) 
            : this(message, statusCode, content, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">Response HTTP status code.</param>
        /// <param name="content">Response content as a string.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public ApiHttpResponseException(string message, HttpStatusCode statusCode, string content, Exception innerException) 
            : base($"{message.Trim().EnsureEndsWith(".")} Status code: '{statusCode.ToReadableString()}'. Content: '{content}'.", innerException)
        {
            StatusCode = statusCode;
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Exceptions.ApiHttpResponseException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected ApiHttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = (HttpStatusCode)info.GetValue(nameof(StatusCode), typeof(HttpStatusCode));
            Content = (string)info.GetValue(nameof(Content), typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(StatusCode), StatusCode, typeof(HttpStatusCode));
            info.AddValue(nameof(Content), Content, typeof(string));
        }
    }
}