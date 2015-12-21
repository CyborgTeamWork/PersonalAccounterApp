using System;
using System.Collections.Generic;

namespace PersonalAccounter.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}