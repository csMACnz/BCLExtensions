using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="Action{TResult}"/> class.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T}"/> as an  <see cref="System.Action"/>.
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
        /// Extension method to expose a <see cref="System.Action{T1,T2}" /> as an  <see cref="System.Action" />.
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
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3}" /> as an  <see cref="System.Action" />.
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

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3,T4}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3,T4>(this Action<T1, T2, T3, T4> action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            return () => action(parameter1, parameter2, parameter3, parameter4);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3,T4,T5}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="T5">The type of the parameter5.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <param name="parameter5">The parameter5.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
        {
            return () => action(parameter1, parameter2, parameter3, parameter4, parameter5);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3,T4,T5,T6}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="T5">The type of the parameter5.</typeparam>
        /// <typeparam name="T6">The type of the parameter6.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <param name="parameter5">The parameter5.</param>
        /// <param name="parameter6">The parameter6.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
        {
            return () => action(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3,T4,T5,T6,T7}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="T5">The type of the parameter5.</typeparam>
        /// <typeparam name="T6">The type of the parameter6.</typeparam>
        /// <typeparam name="T7">The type of the parameter7.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <param name="parameter5">The parameter5.</param>
        /// <param name="parameter6">The parameter6.</param>
        /// <param name="parameter7">The parameter7.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
        {
            return () => action(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3,T4,T5,T6,T7,T8}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="T5">The type of the parameter5.</typeparam>
        /// <typeparam name="T6">The type of the parameter6.</typeparam>
        /// <typeparam name="T7">The type of the parameter7.</typeparam>
        /// <typeparam name="T8">The type of the parameter8.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <param name="parameter5">The parameter5.</param>
        /// <param name="parameter6">The parameter6.</param>
        /// <param name="parameter7">The parameter7.</param>
        /// <param name="parameter8">The parameter8.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7, T8 parameter8)
        {
            return () => action(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8);
        }

        /// <summary>
        /// Extension method to expose a <see cref="System.Action{T1,T2,T3,T4,T5,T6,T7,T8,T9}" /> as an  <see cref="System.Action" />.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter1.</typeparam>
        /// <typeparam name="T2">The type of the parameter2.</typeparam>
        /// <typeparam name="T3">The type of the parameter3.</typeparam>
        /// <typeparam name="T4">The type of the parameter4.</typeparam>
        /// <typeparam name="T5">The type of the parameter5.</typeparam>
        /// <typeparam name="T6">The type of the parameter6.</typeparam>
        /// <typeparam name="T7">The type of the parameter7.</typeparam>
        /// <typeparam name="T8">The type of the parameter8.</typeparam>
        /// <typeparam name="T9">The type of the parameter9.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">The parameter3.</param>
        /// <param name="parameter4">The parameter4.</param>
        /// <param name="parameter5">The parameter5.</param>
        /// <param name="parameter6">The parameter6.</param>
        /// <param name="parameter7">The parameter7.</param>
        /// <param name="parameter8">The parameter8.</param>
        /// <param name="parameter9">The parameter9.</param>
        /// <returns></returns>
        public static Action AsActionUsing<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7, T8 parameter8, T9 parameter9)
        {
            return () => action(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9);
        }
    }
}
