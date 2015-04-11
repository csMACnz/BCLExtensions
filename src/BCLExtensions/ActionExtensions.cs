using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="Action{TResult}"/> class.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T}"/> as an  <see cref="System.Action"/> .
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public static Action AsActionUsing<TParameter>(this Action<TParameter> action, TParameter parameter)
        {
            return () => action(parameter);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2}" /> as an  <see cref="System.Action" /> .
        /// </summary>
        /// <typeparam name="T1">The type of parameter1.</typeparam>
        /// <typeparam name="T2">The type of parameter2.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2>(this Action<T1, T2> action, T1 parameter1, T2 parameter2)
        {
            return () => action(parameter1, parameter2);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3}" /> as an  <see cref="System.Action" /> .
        /// </summary>
        /// <typeparam name="T1">The type of parameter1.</typeparam>
        /// <typeparam name="T2">The type of parameter2.</typeparam>
        /// <typeparam name="T3">The type of parameter3.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3>(this Action<T1, T2, T3> action, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            return () => action(parameter1, parameter2, parameter3);
        }
    }
}
