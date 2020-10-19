using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace syp.biz.Common.NET.Extensions
{
    /// <summary>
    /// A set of <see cref="Enum"/> related extension methods.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute.Description"/> of the <paramref name="enum"/> member of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="enum">The enum member.</param>
        /// <returns>The <see cref="DescriptionAttribute.Description"/> of an enum member if set, otherwise <c>null</c></returns>
        public static string? GetDescription<T>(this T @enum) where T : Enum => @enum
                .GetType() // TODO: check if typeof(T) would work instead
                .GetField(@enum.ToString())
                .GetCustomAttribute<DescriptionAttribute>(false)?
                .Description;

        /// <summary>
        /// Gets a lookup dictionary of the members of <typeparamref name="T"/> and their <see cref="DescriptionAttribute.Description"/>, if defined.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <returns>
        /// An <see cref="IDictionary{TKey,TValue}"/> of the members of the <typeparamref name="T"/> enum
        /// and their <see cref="DescriptionAttribute.Description"/> if defined, otherwise <c>null</c>.
        /// </returns>
        public static IDictionary<T, string?> GetMemberDescriptions<T>() where T : Enum => typeof(T)
            .GetFields()
            .ToDictionary(
                keySelector: f => (T)f.GetValue(null),
                elementSelector: f => f.GetCustomAttribute<DescriptionAttribute>(false)?.Description
            );

        /// <summary>
        /// Gets a lookup dictionary of the <see cref="DescriptionAttribute.Description"/> and their corresponding members of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <returns>
        /// An <see cref="IDictionary{TKey,TValue}"/> of the members of the <see cref="DescriptionAttribute.Description"/>
        /// of members of the <typeparamref name="T"/> enum and their values if defined;<br/>
        /// Members of <typeparamref name="T"/> without a defined <see cref="DescriptionAttribute"/> are excluded.
        /// </returns>
        public static IDictionary<string, T> GetDescriptionMembers<T>() where T : Enum => typeof(T)
                .GetFields()
                .Select(field => new
                {
                    field,
                    desc = field.GetCustomAttribute<DescriptionAttribute>(false)?.Description
                })
                .Where(f => !(f.desc is null))
                .ToDictionary(
                    keySelector: f => f.desc!, 
                    elementSelector: f => (T)f.field.GetValue(null));
    }
}
