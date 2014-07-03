using System;

namespace BCLExtensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object instance)
        {
            return instance == null;
        }

        public static bool IsNotNull(this object instance)
        {
            return instance != null;
        }

        public static void EnsureIsNotNull(this object instance)
        {
            if (instance.IsNull())
            {
                throw new ArgumentNullException();
            }
        }

        public static void EnsureIsNotNull(this object instance, string argumentName)
        {
            if (instance.IsNull())
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
