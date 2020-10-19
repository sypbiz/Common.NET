using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace syp.biz.Common.NET.Extensions
{
    /// <summary>
    /// A set of <see cref="NameValueCollection"/> related extension methods.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Enumerates the <paramref name="collection"/> as a <c>name/value</c> <see cref="Tuple"/>.
        /// </summary>
        /// <param name="collection">The <see cref="NameValueCollection"/> to enumerate.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <c>name/value</c> <see cref="Tuple"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
        public static IEnumerable<(string name, string value)> AsEnumerable(this NameValueCollection collection) => 
            (collection ?? throw new ArgumentNullException(nameof(collection)))
                .Cast<string>()
                .Select(name => (name, collection[name]));
    }
}
