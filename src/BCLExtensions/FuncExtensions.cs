using System;

namespace BCLExtensions
{
    public static class FuncExtensions
    {
        public static Action AsAction<T>(this Func<T> function)
        {
            return () => function();
        }

        public static Action AsActionUsing<TOutput, TParameter>(this Func<TParameter, TOutput> function, TParameter parameter)
        {
            return () => function(parameter);
        }


        public static Action AsActionUsing<TOutput, TParameter1, TParameter2>(this Func<TParameter1, TParameter2, TOutput> function, TParameter1 parameter1, TParameter2 parameter2)
        {
            return () => function(parameter1, parameter2);
        }
    }
}
