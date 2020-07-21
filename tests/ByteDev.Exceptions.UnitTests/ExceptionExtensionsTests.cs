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
    }
}