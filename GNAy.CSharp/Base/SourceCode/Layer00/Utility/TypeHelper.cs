using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Reflection;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_TypeHelper
{
    [Pure]
    internal static class CTypeHelper
    {
        internal static int[] extGetEnumIntValueCollection(this Type ioType)
        {
            return (ioType.GetEnumValues() as int[]);
        }

        internal static long[] extGetEnumLongValueCollection(this Type ioType)
        {
            return (ioType.GetEnumValues() as long[]);
        }

        internal static T[] extGetEnumValueCollection<T>(this Type ioType) where T : struct, IComparable, IFormattable, IConvertible
        {
            return (ioType.GetEnumValues() as T[]);
        }

        internal static object extCreateInstance(this Type ioType, BindingFlags iBindingFlags, params object[] ioArguments)
        {
            return Activator.CreateInstance(ioType, iBindingFlags, null, ioArguments, null);
        }

        internal static T extCreateInstance<T>(this Type ioType, BindingFlags iBindingFlags, params object[] ioArguments)
        {
            return (T)extCreateInstance(ioType, iBindingFlags, ioArguments);
        }

        internal static object extCreateInstance(this Type ioType, params object[] ioArguments)
        {
            return extCreateInstance(ioType, (BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance), ioArguments);
        }

        internal static T extCreateInstance<T>(this Type ioType, params object[] ioArguments)
        {
            return (T)extCreateInstance(ioType, ioArguments);
        }

        internal static object extGetDefault(this Type ioType)
        {
            return (ioType.IsValueType ? Activator.CreateInstance(ioType) : null);
        }

        internal static T GetDefault<T>()
        {
            return default(T);
        }
    }
}
