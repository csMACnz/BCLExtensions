namespace BCLExtensions
{
    /// <summary>
    /// Represents a result that is either successful or has an exception.
    /// </summary>
    /// <typeparam name="TResult">The result, on success.</typeparam>
    /// <typeparam name="TException">The Exception, on failure.</typeparam>
    public class Errorable<TResult, TException>
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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Errorable{TResult, TException}"/> class.
        /// </summary>
        /// <param name="error">The error on failure.</param>
        public Errorable(TException error)
        {
            _successful = true;
            _exception = error;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Successful
        {
            get { return _successful; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TResult Result
        {
            get { return _result; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TException Exception
        {
            get { return _exception; }
        }
    }
}
