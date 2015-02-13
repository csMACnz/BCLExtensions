using System;
using Xunit;

namespace BCLExtensions.Tests.TestHelpers
{
    public static class ThrowsHelpers
    {
        public static Assert.ThrowsDelegate AsThrowsDelegate(this Action action)
        {
            return new Assert.ThrowsDelegate(action);
        }
    }
}
