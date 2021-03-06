﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ByteDev.Exceptions.UnitTests.Serialization;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class DependencyNullExceptionTests
    {
        private const string Message = "some message";
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
            var sut = new DependencyNullException(Message);

            Assert.That(sut.Message, Is.EqualTo(Message));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new DependencyNullException(Message, innerException);

            Assert.That(sut.Message, Is.EqualTo(Message));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenDependencyTypeSpecified_ThenSetMessage()
        {
            var sut = new DependencyNullException(typeof(TestDependency));

            Assert.That(sut.Message, Is.EqualTo("Dependency type 'ByteDev.Exceptions.UnitTests.DependencyNullExceptionTests+TestDependency' cannot be null."));
        }

        [Test]
        public void WhenDependencyTypeIsNull_ThenSetMessage()
        {
            var sut = new DependencyNullException(null as Type);

            Assert.That(sut.Message, Is.EqualTo("Dependency type '' cannot be null."));
        }
        
        [Test]
        public void WhenDependencyType_AndParamName_ThenSetProperties()
        {
            var sut = new DependencyNullException(typeof(TestDependency), ParamName);

            Assert.That(sut.Message, Is.EqualTo($"Dependency type 'ByteDev.Exceptions.UnitTests.DependencyNullExceptionTests+TestDependency' cannot be null. (Parameter '{ParamName}')."));
            Assert.That(sut.ParamName, Is.EqualTo(ParamName));
        }

        [Test]
        public void WhenDependencyTypeAndParamNameIsNull_ThenSetProperties()
        {
            var sut = new DependencyNullException(null as Type, null);

            Assert.That(sut.Message, Is.EqualTo("Dependency type '' cannot be null. (Parameter '')."));
            Assert.That(sut.ParamName, Is.Null);
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var sut = new DependencyNullException(typeof(TestDependency), ParamName);

            var result = Serializer.SerializeAndDeserialize(sut);

            Assert.That(result.ParamName, Is.EqualTo(sut.ParamName));
            Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
        }

        [Test]
        public void WhenSerialized_AndParamNameIsNull_ThenDeserializeCorrectly()
        {
            var sut = new DependencyNullException(typeof(TestDependency), null);

            var result = Serializer.SerializeAndDeserialize(sut);

            Assert.That(result.ParamName, Is.Null);
            Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
        }

        public class TestDependency
        {
        }
    }
}