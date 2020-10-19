using System;
using System.Diagnostics.CodeAnalysis;

namespace syp.biz.Common.NET.Extensions
{
    /// <summary>
    /// A set of <see cref="Uri"/> related extension methods.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class UriExtensions
    {
        /// <summary>
        /// Appends the <paramref name="path"/> to the <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> to append to.</param>
        /// <param name="path">The path to append</param>
        /// <returns>A new <see cref="Uri"/> with the appended <paramref name="path"/>.</returns>
        public static Uri AppendPath(this Uri uri, string path) => new UriBuilder(uri).AppendPath(path).Uri;

        /// <summary>
        /// Appends the <paramref name="path"/> to the <see cref="UriBuilder.Path"/> of <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="UriBuilder"/> to append to.</param>
        /// <param name="path">The path to append</param>
        /// <returns>The provided <paramref name="builder"/> with the appended <paramref name="path"/>.</returns>
        public static UriBuilder AppendPath(this UriBuilder builder, string path)
        {
            builder.Path += path.StartsWith("/") ? path : $"/{path}";
            return builder;
        }
    }
}
