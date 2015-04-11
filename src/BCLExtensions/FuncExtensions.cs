using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="Func{TResult}"/> class.
    /// </summary>
    public static class FuncExtensions
    {
        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T}"/> as an <see cref="System.Action"/> .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static Action AsAction<T>(this Func<T> function)
        {
            return () => function();
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T,TResult}"/> as an  <see cref="System.Action"/> .
        /// </summary>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public static Action AsActionUsing<TOutput, TParameter>(this Func<TParameter, TOutput> function, TParameter parameter)
        {
            return () => function(parameter);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T1,T2,TResult}"/> as an  <see cref="System.Action"/> .
        /// </summary>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <typeparam name="TParameter1">The type of parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of parameter2.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns></returns>
        public static Action AsActionUsing<TOutput, TParameter1, TParameter2>(this Func<TParameter1, TParameter2, TOutput> function, TParameter1 parameter1, TParameter2 parameter2)
        {
            return () => function(parameter1, parameter2);
        }


        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T1,T2,T3,TResult}" /> as an  <see cref="System.Action" /> .
        /// </summary>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <typeparam name="TParameter1">The type of parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of parameter3.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <returns></returns>
        public static Action AsActionUsing<TOutput, TParameter1, TParameter2, TParameter3>(this Func<TParameter1, TParameter2, TParameter3, TOutput> function, TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3)
        {
            return () => function(parameter1, parameter2, parameter3);
        }
    }
}
