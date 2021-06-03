using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ByteDev.Exceptions.UnitTests.Serialization;
using ByteDev.Exceptions.UnitTests.TestTypes;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class UnexpectedEnumValueExceptionTests
    {
        private const string Message = "some message";

        [Test]
        public void WhenNoArgs_ThenSetProperties()
        {
            var sut = new UnexpectedEnumValueException<Color>();

            Assert.That(sut.Message, Is.EqualTo("Unexpected value for enum 'ByteDev.Exceptions.UnitTests.TestTypes.Color'."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetProperties()
        {
            var sut = new UnexpectedEnumValueException<Color>(Message);

            Assert.That(sut.Message, Is.EqualTo(Message));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetProperties()
        {
            var innerException = new Exception();

            var sut = new UnexpectedEnumValueException<Color>(Message, innerException);

            Assert.That(sut.Message, Is.EqualTo(Message));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenEnumValueSpecified_ThenSetMessage()
        {
            var sut = new UnexpectedEnumValueException<Color>(Color.Red);

            Assert.That(sut.Message, Is.EqualTo("Unexpected value 'Red' for enum 'ByteDev.Exceptions.UnitTests.TestTypes.Color'."));
        }

        [Test]
        public void WhenEnumValueOutOfBounds_ThenSetProperties()
        {
            var sut = new UnexpectedEnumValueException<Color>((Color)99);

            Assert.That(sut.Message, Is.EqualTo("Unexpected value '99' for enum 'ByteDev.Exceptions.UnitTests.TestTypes.Color'."));
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var sut = new UnexpectedEnumValueException<Color>(Message);

            var result = Serializer.SerializeAndDeserialize(sut);
 
            Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
        }
    }
}