using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Internal.L2_ArrayExtensions;
using GNAy.CSharp.Base.Internal.L2_LibrarySetting;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L3_EnumerableTExtensions
{
    [Pure]
    internal static class CEnumerableTExtensions
    {
        internal static string extToString(this IEnumerable<char> ioSource, int iStartIndex)
        {
            return CArrayExtensions.extToString(((ioSource is char[]) ? (ioSource as char[]) : ioSource.ToArray()), iStartIndex);
        }

        internal static string extToString(this IEnumerable<char> ioSource, int iStartIndex, int iCount)
        {
            return CArrayExtensions.extToString(((ioSource is char[]) ? (ioSource as char[]) : ioSource.ToArray()), iStartIndex, iCount);
        }

        internal static string extToStringPool(this IEnumerable<char> ioSource, int iStartIndex)
        {
            return string.Intern(extToString(ioSource, iStartIndex));
        }

        internal static string extToStringPool(this IEnumerable<char> ioSource, int iStartIndex, int iCount)
        {
            return string.Intern(extToString(ioSource, iStartIndex, iCount));
        }

        internal static string extDefaultJoin<T>(this IEnumerable<T> ioSource)
        {
            return string.Format(CLibrarySetting.GetBucket(), string.Join(CLibrarySetting.GetSeparator(), ioSource));
        }
    }
}
