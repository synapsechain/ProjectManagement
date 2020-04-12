using System.Linq;
using System.Collections.Generic;

namespace ProjectManagement.Data.Tools
{
    public static  class Extensions
    {
        public static IEnumerable<T> NeverNull<T>(this IEnumerable<T> value) =>
            value ?? Enumerable.Empty<T>();
    }
}
