using System;
using ByteDev.Exceptions.UnitTests.TestTypes;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class EntityNotFoundExceptonsTests
    {
        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new EntityNotFoundException();

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetMessage()
        {
            var sut = new EntityNotFoundException("Some message.");

            Assert.That(sut.Message, Is.EqualTo("Some message."));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new EntityNotFoundException("Some message.", innerException);

            Assert.That(sut.Message, Is.EqualTo("Some message."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenTypeSpecified_ThenSetProperties()
        {
            var sut = new EntityNotFoundException(typeof(DummyEntity));

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist of type: 'ByteDev.Exceptions.UnitTests.TestTypes.DummyEntity'."));
            Assert.That(sut.EntityType, Is.EqualTo(typeof(DummyEntity)));
            Assert.That(sut.EntityId, Is.Null);
        }

        [Test]
        public void WhenTypeAndIdSpecified_ThenSetMessage()
        {
            var sut = new EntityNotFoundException(typeof(DummyEntity), "A1");

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist of type: 'ByteDev.Exceptions.UnitTests.TestTypes.DummyEntity' with ID: 'A1'."));
            Assert.That(sut.EntityType, Is.EqualTo(typeof(DummyEntity)));
            Assert.That(sut.EntityId, Is.EqualTo("A1"));
        }
    }
}