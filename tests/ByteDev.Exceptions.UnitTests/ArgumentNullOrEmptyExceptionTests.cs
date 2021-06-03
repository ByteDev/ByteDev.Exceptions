using System;
using ByteDev.Exceptions.UnitTests.Serialization;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class ArgumentNullOrEmptyExceptionTests
    {
        private const string Message = "some message";
        private const string ParamName = "myArg";

        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new ArgumentNullOrEmptyException();
            
            Assert.That(sut.Message, Is.EqualTo("Value cannot be null or empty."));
        }

        [Test]
        public void WhenParamNameSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentNullOrEmptyException(ParamName);

            Assert.That(sut.Message, Is.EqualTo("Value cannot be null or empty. (Parameter 'myArg')"));
            Assert.That(sut.ParamName, Is.EqualTo(ParamName));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new ArgumentNullOrEmptyException(Message, innerException);

            Assert.That(sut.Message, Is.EqualTo(Message));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenParamNameAndMessageSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentNullOrEmptyException(ParamName, Message);

            Assert.That(sut.Message, Is.EqualTo($"{Message} (Parameter 'myArg')"));
            Assert.That(sut.ParamName, Is.EqualTo(ParamName));
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var sut = new ArgumentNullOrEmptyException(ParamName, Message);

            var result = Serializer.SerializeAndDeserialize(sut);

            Assert.That(result.ParamName, Is.EqualTo(sut.ParamName));
            Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
        }
    }
}