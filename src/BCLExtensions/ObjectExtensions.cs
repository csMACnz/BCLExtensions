using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.Object"/> class.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Ensures that the instance is not null, or throws an exception.
        /// </summary>
        /// <param name="instance">The object to verify.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when instance is null.</exception>
        public static void EnsureIsNotNull(this object instance)
        {
            if (instance.IsNull())
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Ensures that the instance is not null, or throws an exception.
        /// </summary>
        /// <param name="instance">The object to verify.</param>
        /// <param name="argumentName">The argumentName to use when exception is thrown.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when argumentName is null, or instance is null.</exception>
        public static void EnsureIsNotNull(this object instance, string argumentName)
        {
            if (instance.IsNull())
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Checks whether the instance provided is not null.
        /// </summary>
        /// <param name="instance">The instance to check.</param>
        /// <returns>true if instance is not null; otherwise false.</returns>
        public static bool IsNotNull(this object instance)
        {
            return instance != null;
        }

        /// <summary>
        /// Checks whether the instance provided is null.
        /// </summary>
        /// <param name="instance">The instance to check.</param>
        /// <returns>true if instance is null; otherwise false.</returns>
        public static bool IsNull(this object instance)
        {
            return instance == null;
        }
    }
}
