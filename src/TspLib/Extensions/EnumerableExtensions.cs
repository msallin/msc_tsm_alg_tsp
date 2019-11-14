using System;
using System.Collections.Generic;
using System.Linq;

namespace HeuLib.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> WithoutFirst<T>(this IEnumerable<T> input)
        {
            return input
                .Reverse()
                .Take(input.Count() - 1)
                .Reverse();
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.Shuffle(new Random());

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (rng == null)
            {
                throw new ArgumentNullException("rng");
            }

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                var j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}