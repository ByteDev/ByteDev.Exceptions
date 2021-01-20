using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class DependencyNullExceptionTests
    {
        private const string ParamName = "myDependency";

        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new DependencyNullException();

            Assert.That(sut.Message, Is.EqualTo("Dependency cannot be null."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetMessage()
        {
            var sut = new DependencyNullException("Some message.");

            Assert.That(sut.Message, Is.EqualTo("Some message."));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new DependencyNullException("Some message.", innerException);

            Assert.That(sut.Message, Is.EqualTo("Some message."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenDependencyTypeSpecified_ThenSetMessage()
        {
            var sut = new DependencyNullException(typeof(TestDependency));

            Assert.That(sut.Message, Is.EqualTo("Dependency type 'ByteDev.Exceptions.UnitTests.DependencyNullExceptionTests+TestDependency' cannot be null."));
        }

        [Test]
        public void WhenDependencyType_AndParamName_ThenSetMessage()
        {
            var sut = new DependencyNullException(typeof(TestDependency), ParamName);

            Assert.That(sut.Message, Is.EqualTo($"Dependency type 'ByteDev.Exceptions.UnitTests.DependencyNullExceptionTests+TestDependency' cannot be null. (Parameter '{ParamName}')."));
        }

        [Test]
        public void WhenSerialized_ThenSavesParamName()
        {
            var sut = new DependencyNullException(typeof(TestDependency), ParamName);

            var formatter = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, sut);

                stream.Seek(0, 0);

                var result = (DependencyNullException)formatter.Deserialize(stream);

                Assert.That(result.ParamName, Is.EqualTo(sut.ParamName));
                Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
            }
        }

        public class TestDependency
        {
        }
    }
}