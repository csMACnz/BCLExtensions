using System;

namespace BCLExtensions
{
    /// <summary>
    /// Represents a result that is either successful or has an exception.
    /// </summary>
    /// <typeparam name="TResult">The result, on success.</typeparam>
    /// <typeparam name="TException">The Exception, on failure.</typeparam>
    public struct Errorable<TResult, TException>
    {
        private readonly TException _exception;
        private readonly TResult _result;
        private readonly bool _successful;

        /// <summary>
        /// Initializes a new instance of the <see cref="Errorable{TResult, TException}"/> class.
        /// </summary>
        /// <param name="result">The result on success.</param>
        public Errorable(TResult result)
        {
            _successful = true;
            _result = result;
            _exception = default(TException);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Errorable{TResult, TException}"/> class.
        /// </summary>
        /// <param name="error">The error on failure.</param>
        public Errorable(TException error)
        {
            error.EnsureIsNotNull("error");
            _successful = false;
            _exception = error;
            _result = default(TResult);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Errorable{TResult, TException}"/> is successful.
        /// </summary>
        public bool Successful
        {
            get
            {
                if (!_successful && _exception.IsNull())
                {
                    throw new InvalidErrorableException();
                }
                return _successful;
            }
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Result cannot be accessed on unsuccessful Errorable</exception>
        public TResult Result
        {
            get
            {
                if (_successful) return _result;
                if (_exception.IsNull())
                {
                    throw new InvalidErrorableException();
                }
                throw new InvalidOperationException("Result cannot be accessed on unsuccessful Errorable");
            }
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Exception cannot be accessed on unsuccessful Errorable</exception>
        /// <exception cref="BCLExtensions.Errorable{TResult, TException}.InvalidErrorableException"></exception>
        public TException Exception
        {
            get
            {
                if (_successful)
                    throw new InvalidOperationException("Exception cannot be accessed on unsuccessful Errorable");
                if (_exception != null) return _exception;
                throw new InvalidErrorableException();
            }
        }

        /// <summary>
        /// Represented an Unexpected state of the Errorable Object. 
        /// This only happens as an edge case default construction of the Errorable Object ( default(<see cref="Errorable{TResult, TException}"/>) )
        /// </summary>
        public class InvalidErrorableException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InvalidErrorableException"/> class.
            /// </summary>
            public InvalidErrorableException() : base("This errorable was constructed incorrectly by the provider")
            {
            }
        }
    }
}
