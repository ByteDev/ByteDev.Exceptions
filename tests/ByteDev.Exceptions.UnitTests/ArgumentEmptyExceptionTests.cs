using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class ArgumentEmptyExceptionTests
    {
        private const string Message = "some message";
        private const string ParamName = "myArg";

        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new ArgumentEmptyException();

            Assert.That(sut.Message, Is.EqualTo("Value cannot be empty."));
        }

        [Test]
        public void WhenParamNameSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentEmptyException(ParamName);

            Assert.That(sut.Message, Is.EqualTo($"Value cannot be empty. (Parameter '{ParamName}')"));
            Assert.That(sut.ParamName, Is.EqualTo(ParamName));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new ArgumentEmptyException(Message, innerException);

            Assert.That(sut.Message, Is.EqualTo(Message));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenParamNameAndMessageSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentEmptyException(ParamName, Message);

            Assert.That(sut.Message, Is.EqualTo($"{Message} (Parameter '{ParamName}')"));
            Assert.That(sut.ParamName, Is.EqualTo(ParamName));
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var sut = new ArgumentEmptyException(ParamName, Message);

            var formatter = new BinaryFormatter();
            
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, sut);

                stream.Seek(0, 0);

                var result = (ArgumentEmptyException)formatter.Deserialize(stream);

                Assert.That(result.ParamName, Is.EqualTo(sut.ParamName));
                Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
            }
        }
    }
}