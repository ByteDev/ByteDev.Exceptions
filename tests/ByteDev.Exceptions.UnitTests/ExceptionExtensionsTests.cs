using System;
using NUnit.Framework;

namespace ByteDev.Exceptions.UnitTests
{
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        [TestFixture]
        public class AllMessages
        {
            private const string Message1 = "Message1";
            private const string Message2 = "Message2";
            private const string Message3 = "Message3";

            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = ExceptionExtensions.AllMessages(null));
            }

            [Test]
            public void WhenNoInnerException_ThenReturnString()
            {
                var sut = new Exception(Message1);

                var result = sut.AllMessages();

                Assert.That(result, Is.EqualTo(Message1));
            }

            [Test]
            public void WhenMultipleInnerExceptions_ThenReturnString()
            {
                string expected = 
                        Message1 + Environment.NewLine +
                        "-- " + Message2 + Environment.NewLine +
                        "---- " + Message3;

                var ex3 = new Exception(Message3);
                var ex2 = new Exception(Message2, ex3);

                var sut = new Exception(Message1, ex2);
                
                var result = sut.AllMessages();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Find
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = ExceptionExtensions.FindInner<Exception>(null));
            }

            [Test]
            public void WhenNoInnerException_ThenReturnNull()
            {
                var sut = new Exception();

                var result = sut.FindInner<InvalidOperationException>();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenInnerExceptionIsType_ThenReturnInner()
            {
                var inner = new ArgumentException();

                var sut = new Exception("Test error", inner);

                var result = sut.FindInner<ArgumentException>();

                Assert.That(result, Is.SameAs(inner));
            }

            [Test]
            public void WhenFirstInnerAndSecondInnerIsType_ThenReturnFirstInner()
            {
                var inner2 = new ArgumentException();
                var inner1 = new ArgumentException("Test error", inner2);

                var sut = new Exception("Test error", inner1);

                var result = sut.FindInner<ArgumentException>();

                Assert.That(result, Is.SameAs(inner1));
            }

            [Test]
            public void WhenSecondInnerIsType_ThenReturnSecondInner()
            {
                var inner2 = new ArgumentNullException();
                var inner1 = new ArgumentException("Test error", inner2);

                var sut = new Exception("Test error", inner1);

                var result = sut.FindInner<ArgumentNullException>();

                Assert.That(result, Is.SameAs(inner2));
            }

            [Test]
            public void WhenInnerIsBaseType_ThenReturnNull()
            {
                // Method only supports exact type match (not "is" style match)

                var sut = new Exception("Test error", new ArgumentNullException());

                var result = sut.FindInner<ArgumentException>();

                Assert.That(result, Is.Null);
            }
        }
    }
}