using System;
using ByteDev.Exceptions.UnitTests.TestTypes;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class UnexpectedEnumValueExceptionTests
    {
        [Test]
        public void WhenNoArgs_ThenSetProperties()
        {
            var sut = new UnexpectedEnumValueException<Color>();

            Assert.That(sut.Message, Is.EqualTo("Unexpected value for enum 'ByteDev.Exceptions.UnitTests.TestTypes.Color'."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetProperties()
        {
            var sut = new UnexpectedEnumValueException<Color>("some message.");

            Assert.That(sut.Message, Is.EqualTo("some message."));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetProperties()
        {
            var innerException = new Exception();

            var sut = new UnexpectedEnumValueException<Color>("some message.", innerException);

            Assert.That(sut.Message, Is.EqualTo("some message."));
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
    }
}