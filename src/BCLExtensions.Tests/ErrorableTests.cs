using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests
{
    public class ErrorableTests
    {
        public class ProvidedValidString
        {
            private const string TestResult = "My Result";
            private readonly Errorable<string, Exception> _errorable;

            public ProvidedValidString()
            {
                const string result = TestResult;
                _errorable = new Errorable<string, Exception>(result);
            }

            [Fact]
            public void ConstructsSuccessfully()
            {
                Assert.NotNull(_errorable);
            }

            [Fact]
            public void IsSuccessful()
            {
                Assert.True(_errorable.Successful);
            }

            [Fact]
            public void ReturnsInputResult()
            {
                Assert.Equal(TestResult, _errorable.Result);
            }

            [Fact]
            public void ThrowsWhenYouAccessException()
            {
                AssertThrowsException<Exception, InvalidOperationException>(_errorable, GetException);
            }
        }

        public class ProvidedNullString
        {
            private readonly Errorable<string, Exception> _errorable;

            public ProvidedNullString()
            {
                const string result = null;

                _errorable = new Errorable<string, Exception>(result);
            }

            [Fact]
            public void ConstructsSuccessfully()
            {
                Assert.NotNull(_errorable);
            }

            [Fact]
            public void IsSuccessful()
            {
                Assert.True(_errorable.Successful);
            }

            [Fact]
            public void ReturnsInputResult()
            {
                Assert.Equal(null, _errorable.Result);
            }

            [Fact]
            public void ThrowsWhenYouAccessException()
            {
                AssertThrowsException<Exception, InvalidOperationException>(_errorable, GetException);
            }
        }

        public class ProvidedException
        {
            private readonly Errorable<string, Exception> _errorable;

            public ProvidedException()
            {
                Exception result = new Exception();
                _errorable = new Errorable<string, Exception>(result);
            }

            [Fact]
            public void ConstructsSuccessfully()
            {
                Assert.NotNull(_errorable);
            }

            [Fact]
            public void IsNotSuccessful()
            {
                Assert.False(_errorable.Successful);
            }

            [Fact]
            public void ThrowsWhenYouAccessResult()
            {
                AssertThrowsException<string, InvalidOperationException>(_errorable, GetResult);
            }
        }

        [Fact]
        public void ProvidedNullExceptionThrows()
        {
            Exception exception = null;

            Func<Exception, Errorable<string, Exception>> function = CreateErrorableFrom;

            Assert.Throws<ArgumentNullException>(function.AsActionUsing(exception).AsThrowsDelegate());
        }

        private static Errorable<string, Exception> CreateErrorableFrom(Exception exception)
        {
            return new Errorable<string, Exception>(exception);
        }

        public class WhenConstructedUsingDefault
        {
            private readonly Errorable<string, Exception> _errorable;

            public WhenConstructedUsingDefault()
            {
                _errorable = default(Errorable<string, Exception>);
            }

            [Fact]
            public void ThrowsWhenYouAccessSuccessful()
            {
                AssertThrowsException<bool, Errorable<string, Exception>.InvalidErrorableException>(_errorable, GetSuccessful);
            }

            [Fact]
            public void ThrowsWhenYouAccessResult()
            {
                AssertThrowsException<string, Errorable<string, Exception>.InvalidErrorableException>(_errorable, GetResult);
            }

            [Fact]
            public void ThrowsWhenYouAccessException()
            {
                AssertThrowsException<Exception, Errorable<string, Exception>.InvalidErrorableException>(_errorable, GetException);
            }
        }

        public class WhenConstructedUsingDefaultConstructor
        {
            private readonly Errorable<string, Exception> _errorable;

            public WhenConstructedUsingDefaultConstructor()
            {
                _errorable = new Errorable<string, Exception>();
            }

            [Fact]
            public void ThrowsWhenYouAccessSuccessful()
            {
                AssertThrowsException<bool, Errorable<string, Exception>.InvalidErrorableException>(_errorable, GetSuccessful);
            }

            [Fact]
            public void ThrowsWhenYouAccessResult()
            {
                AssertThrowsException<string, Errorable<string, Exception>.InvalidErrorableException>(_errorable, GetResult);
            }

            [Fact]
            public void ThrowsWhenYouAccessException()
            {
                AssertThrowsException<Exception, Errorable<string, Exception>.InvalidErrorableException>(_errorable, GetException);
            }
        }


        private static void AssertThrowsException<T, TException>(Errorable<string, Exception> errorable, Func<Errorable<string, Exception>, T> action) where TException : Exception
        {
            Assert.Throws<TException>(action.AsActionUsing(errorable).AsThrowsDelegate());
        }

        private static Exception GetException(Errorable<string, Exception> errorable)
        {
            return errorable.Exception;
        }

        private static string GetResult(Errorable<string, Exception> errorable)
        {
            return errorable.Result;
        }

        private static bool GetSuccessful(Errorable<string, Exception> errorable)
        {
            return errorable.Successful;
        }
    }
}
