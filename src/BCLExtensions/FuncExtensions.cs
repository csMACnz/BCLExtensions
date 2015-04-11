using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="Func{TResult}"/> class.
    /// </summary>
    public static class FuncExtensions
    {
        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T}"/> as an <see cref="System.Action"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static Action AsAction<T>(this Func<T> function)
        {
            return () => function();
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T,TResult}"/> as an  <see cref="System.Action"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the output.</typeparam>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T, TResult>(this Func<T, TResult> function, T parameter)
        {
            return () => function(parameter);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T1,T2,TResult}"/> as an  <see cref="System.Action"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the output.</typeparam>
        /// <typeparam name="T1">The type of parameter1.</typeparam>
        /// <typeparam name="T2">The type of parameter2.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, TResult>(this Func<T1, T2, TResult> function, T1 parameter1, T2 parameter2)
        {
            return () => function(parameter1, parameter2);
        }


        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T1,T2,T3,TResult}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="TResult">The type of the output.</typeparam>
        /// <typeparam name="T1">The type of parameter1.</typeparam>
        /// <typeparam name="T2">The type of parameter2.</typeparam>
        /// <typeparam name="T3">The type of parameter3.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            return () => function(parameter1, parameter2, parameter3);
        }
        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T1,T2,T3,T4,TResult}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            return () => function(parameter1, parameter2, parameter3, parameter4);
        }
        /// <summary>
        /// Extension method to expose a <see cref="System.Func{T1,T2,T3,T4,T5,TResult}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="T5">The type of the parameter5.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <param name="parameter5">The parameter5.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> function, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
        {
            return () => function(parameter1, parameter2, parameter3, parameter4, parameter5);
        }
    }
}
