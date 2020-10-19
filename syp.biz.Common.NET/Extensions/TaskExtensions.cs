using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace syp.biz.Common.NET.Extensions
{
    /// <summary>
    /// A set of <see cref="Task"/> related extension methods.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class TaskExtensions
    {
        /// <summary>
        /// Ignores the awaitable task while disabling context capture.
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to ignore</param>
        /// <remarks>
        /// Implemented as calling <see cref="Task.ConfigureAwait"/> with <c>false</c>.
        /// </remarks>
        public static void IgnoreAwait(this Task task) => task.ConfigureAwait(false);
    }
}
