using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableExtensions
{
    public static class EnumerableMethods
    {
        public static bool HasCount<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable != null)
                foreach (var item in enumerable)
                    return true;

            return false;
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> enumerable, int chunkSize)
        {
            if (chunkSize <= 0)
                throw new ArgumentException("chunkSize must be positive non zero");

            if (enumerable == null)
                throw new ArgumentNullException("enumerable must be a non null reference");

            var response = new List<IEnumerable<T>> { enumerable.Take(chunkSize) };
            
            var enumerableCount = enumerable.Count();
           
            for (var count = chunkSize; count < enumerableCount; count += chunkSize)
                response.Add(enumerable.Skip(count).Take(chunkSize));

            return response;
        }
        
        public static IEnumerable<T> ToEnumerable<T>(this T item)
            where T : class, IComparable
        {
            if (item == default(T) && typeof(T) != typeof(int))
                throw new ArgumentException("item must be a non null reference");

            return new List<T> { item };
        }
    }
}
