using System;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class ArgumentEmptyExceptionTests
    {
        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new ArgumentEmptyException();

            Assert.That(sut.Message, Is.EqualTo("Value cannot be empty."));
        }

        [Test]
        public void WhenParamNameSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentEmptyException("myArg");

            Assert.That(sut.Message, Is.EqualTo("Value cannot be empty. (Parameter 'myArg')"));
            Assert.That(sut.ParamName, Is.EqualTo("myArg"));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new ArgumentEmptyException("some message.", innerException);

            Assert.That(sut.Message, Is.EqualTo("some message."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenParamNameAndMessageSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentEmptyException("myArg", "some message.");

            Assert.That(sut.Message, Is.EqualTo("some message. (Parameter 'myArg')"));
            Assert.That(sut.ParamName, Is.EqualTo("myArg"));
        }
    }
}