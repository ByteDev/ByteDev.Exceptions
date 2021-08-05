using System;
using ByteDev.Exceptions.UnitTests.Serialization;
using ByteDev.Exceptions.UnitTests.TestTypes;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class EntityNotFoundExceptionTests
    {
        private const string Message = "some message";
        private const string EntityId = "1";

        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new EntityNotFoundException();

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetMessage()
        {
            var sut = new EntityNotFoundException(Message);

            Assert.That(sut.Message, Is.EqualTo(Message));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new EntityNotFoundException(Message, innerException);

            Assert.That(sut.Message, Is.EqualTo(Message));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenTypeSpecified_ThenSetMessage()
        {
            var sut = new EntityNotFoundException(typeof(DummyEntity));

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist of type: 'ByteDev.Exceptions.UnitTests.TestTypes.DummyEntity'."));
            Assert.That(sut.EntityId, Is.Null);
        }

        [Test]
        public void WhenTypeIsNull_ThenSetMessage()
        {
            var sut = new EntityNotFoundException(null as Type);

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist of type: ''."));
            Assert.That(sut.EntityId, Is.Null);
        }

        [Test]
        public void WhenTypeAndIdSpecified_ThenSetProperties()
        {
            var sut = new EntityNotFoundException(typeof(DummyEntity), EntityId);

            Assert.That(sut.Message, Is.EqualTo($"Entity does not exist of type: 'ByteDev.Exceptions.UnitTests.TestTypes.DummyEntity' with ID: '{EntityId}'."));
            Assert.That(sut.EntityId, Is.EqualTo(EntityId));
        }

        [Test]
        public void WhenTypeAndIdIsNull_ThenSetMessage()
        {
            var sut = new EntityNotFoundException(null, null as string);

            Assert.That(sut.Message, Is.EqualTo("Entity does not exist of type: '' with ID: ''."));
            Assert.That(sut.EntityId, Is.Null);
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var sut = new EntityNotFoundException(typeof(DummyEntity), EntityId);

            var result = Serializer.SerializeAndDeserialize(sut);

            Assert.That(result.EntityId, Is.EqualTo(sut.EntityId));
            Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
        }

        [Test]
        public void WhenSerialized_AndEntityIdIsNull_ThenDeserializeCorrectly()
        {
            var sut = new EntityNotFoundException(typeof(DummyEntity), null);

            var result = Serializer.SerializeAndDeserialize(sut);

            Assert.That(result.EntityId, Is.Null);
            Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
        }
    }
}