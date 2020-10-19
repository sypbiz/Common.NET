using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace syp.biz.Common.NET.Utils
{
    /// <summary>
    /// A set of randomizing methods.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Random
    {
        private static readonly IReadOnlyList<char> RandomStringChars = "abcdefghijklmnopqrstuvwxyz012345".ToCharArray();
        private static readonly System.Random RandomSource = new System.Random(DateTime.UtcNow.Millisecond);

        /// <summary>
        /// Gets a string of random characters.
        /// </summary>
        /// <param name="length">The length of string to produce.</param>
        /// <param name="charSource">Optional. A collection of <see cref="char"/> to use in the randomization. Default is <c>a-z0-5</c>.</param>
        /// <returns>A string of (<paramref name="length"/> long) random characters from <paramref name="charSource"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> less than <c>1</c>.</exception>
        public static string GetString(int length, IReadOnlyList<char>? charSource = default)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length), "Length must be at least 1");
            charSource ??= RandomStringChars;

            var buffer = new byte[length];
            var charsLength = charSource.Count;

            System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(buffer);

            var chars = buffer
                .Select(b => b % charsLength) // relative position (index) of random byte in RandomStringChars
                .Select(idx => charSource[idx]); // select char for index

            return new StringBuilder(length).Append(chars).ToString();
        }

        /// <summary>
        /// Gets a random <see cref="long"/> between <c>0</c>-<paramref name="max"/> (exclusive).
        /// </summary>
        /// <param name="max">The maximal number to return.</param>
        /// <returns>A random <see cref="long"/> between <c>0</c>-<paramref name="max"/> (exclusive).</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static long GetNumber(long max) => (long) Math.Floor(RandomSource.NextDouble() * max);

        /// <summary>
        /// Gets a left-<c>0</c>-padded string of a number between <c>0</c>-<paramref name="max"/> (exclusive).
        /// </summary>
        /// <param name="max">The maximal number to return.</param>
        /// <returns>A left-<c>0</c>-padded string of a number between <c>0</c>-<paramref name="max"/> (exclusive).</returns>
        /// <example>
        /// GetNumberString(100) --> "00"-"99"
        /// GetNumberString(101) --> "000"-"100"
        /// </example>
        public static string GetNumberString(long max)
        {
            var t = (max - 1).ToString().Length;
            var num = GetNumber(max);
            return num.ToString().PadLeft(t, '0');
        }
    }
}
