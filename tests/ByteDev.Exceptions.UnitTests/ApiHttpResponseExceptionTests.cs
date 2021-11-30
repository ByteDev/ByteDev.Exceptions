using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class ApiHttpResponseExceptionTests
    {
        private const string ExMessage = "some message";
        private const string Content = "This is some content";

        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new ApiHttpResponseException();

            Assert.That(sut.Message, Is.EqualTo("Error occurred from API response."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetProperties()
        {
            var sut = new ApiHttpResponseException(ExMessage);

            Assert.That(sut.Message, Is.EqualTo(ExMessage));
            Assert.That(sut.InnerException, Is.Null);
            Assert.That(sut.StatusCode, Is.EqualTo((HttpStatusCode)0));
            Assert.That(sut.Content, Is.Null);
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetProperties()
        {
            var innerException = new Exception();

            var sut = new ApiHttpResponseException(ExMessage, innerException);

            Assert.That(sut.Message, Is.EqualTo(ExMessage));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
            Assert.That(sut.StatusCode, Is.EqualTo((HttpStatusCode)0));
            Assert.That(sut.Content, Is.Null);
        }

        [Test]
        public void WhenMessageAndStatusCodeSpecified_ThenSetProperties()
        {
            var sut = new ApiHttpResponseException(ExMessage, HttpStatusCode.NotFound);

            Assert.That(sut.Message, Is.EqualTo($"{ExMessage}. Status code: '404 NotFound'."));
            Assert.That(sut.InnerException, Is.Null);
            Assert.That(sut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(sut.Content, Is.Null);
        }

        [Test]
        public void WhenMessageAndStatusCodeAndInnerExSpecified_ThenSetProperties()
        {
            var innerException = new Exception();

            var sut = new ApiHttpResponseException(ExMessage, HttpStatusCode.NotFound, innerException);

            Assert.That(sut.Message, Is.EqualTo($"{ExMessage}. Status code: '404 NotFound'."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
            Assert.That(sut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(sut.Content, Is.Null);
        }

        [Test]
        public void WhenMessageAndStatusCodeAndContentSpecified_ThenSetProperties()
        {
            var sut = new ApiHttpResponseException(ExMessage, HttpStatusCode.NotFound, Content);

            Assert.That(sut.Message, Is.EqualTo($"{ExMessage}. Status code: '404 NotFound'. Content: '{Content}'."));
            Assert.That(sut.InnerException, Is.Null);
            Assert.That(sut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(sut.Content, Is.EqualTo(Content));
        }

        [Test]
        public void WhenMessageAndStatusCodeAndContentAndInnerExSpecified_ThenSetProperties()
        {
            var innerException = new Exception();

            var sut = new ApiHttpResponseException(ExMessage, HttpStatusCode.NotFound, Content, innerException);

            Assert.That(sut.Message, Is.EqualTo($"{ExMessage}. Status code: '404 NotFound'. Content: '{Content}'."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
            Assert.That(sut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(sut.Content, Is.EqualTo(Content));
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var innerException = new Exception("This is an inner exception.");

            var sut = new ApiHttpResponseException(ExMessage, HttpStatusCode.NotFound, Content, innerException);

            var formatter = new BinaryFormatter();
            
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, sut);

                stream.Seek(0, 0);

                var result = (ApiHttpResponseException)formatter.Deserialize(stream);

                Assert.That(result.StatusCode, Is.EqualTo(sut.StatusCode));
                Assert.That(result.Content, Is.EqualTo(sut.Content));

                Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));

                Console.WriteLine(result.ToString());
            }
        }
    }
}