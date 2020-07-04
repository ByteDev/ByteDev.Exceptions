using System;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class ArgumentDefaultExceptionTests
    {
        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new ArgumentDefaultException();

            Assert.That(sut.Message, Is.EqualTo("Value cannot be default."));
        }

        [Test]
        public void WhenParamNameSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentDefaultException("myArg");

            Assert.That(sut.Message, Is.EqualTo("Value cannot be default. (Parameter 'myArg')"));
            Assert.That(sut.ParamName, Is.EqualTo("myArg"));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new ArgumentDefaultException("some message.", innerException);

            Assert.That(sut.Message, Is.EqualTo("some message."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenParamNameAndMessageSpecified_ThenSetMessageAndParamName()
        {
            var sut = new ArgumentDefaultException("myArg", "some message.");

            Assert.That(sut.Message, Is.EqualTo("some message. (Parameter 'myArg')"));
            Assert.That(sut.ParamName, Is.EqualTo("myArg"));
        }
    }
}