using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCLExtensions
{
    public static class GenericExtensions
    {
        public static T GetValueOrDefault<T>(this T item, T defaultValue) where T : class
        {
            if (defaultValue == null) throw new ArgumentNullException("defaultValue");
            if (item != null) return item;
            return defaultValue;
        }
    }
}
