using System;
using System.Collections.Generic;

namespace syp.biz.Common.NET.Extensions
{
    /// <summary>
    /// A set of <see cref="IEnumerable{T}"/> related extension methods.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified <paramref name="action"/> on each element of the <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">The <see cref="IEnumerable{T}"/> sequence of elements to perform the <paramref name="action"/> on.</param>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <paramref name="sequence"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/> or <paramref name="action"/> are <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">An element in the <paramref name="sequence"/> has been modified.</exception>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence is null) throw new ArgumentNullException(nameof(sequence));
            if (action is null) throw new ArgumentNullException(nameof(action));

            foreach (var element in sequence) action(element);
        }
    }
}
